<template>
    <form-modal 
        headerText="Feature"
        @close="close" 
        @save="save"
    >
        <q-input class="full-width" dense outlined v-model="v$.name.$model" :error="v$.name.$error" error-message="Name is required." label="Name" />
    </form-modal>
</template>

<script lang="ts">
import { defineComponent, PropType, reactive } from 'vue';
import { required } from '@vuelidate/validators';
import { Feature } from 'src/shared/core/entities/feature.model';

import useVuelidate from '@vuelidate/core';

import FormModal from 'src/shared/components/modals/form-modal/FormModal.vue';

export default defineComponent({
    components: { FormModal },
    emits: ['close', 'save'],
    props: {
        feature: {
            type: Object as PropType<Feature>,
            required: true
        }
    },
    setup(props, { emit }) {
        const feature = reactive<Feature>(props.feature);

        const validationRules = {
            name: { required }
        }

        const v$ = useVuelidate(validationRules, feature);

        async function save() {
            const isValid = await v$.value.$validate();

            if (!isValid) return;

            emit('save', feature);
        }

        function close() {
            emit('close');
        }

        return {
            v$,
            save,
            close
        }
    }
})
</script>
