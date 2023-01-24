<template>
    <form-modal 
        headerText="Platform"
        @close="close" 
        @save="save"
    >
        <q-input class="full-width" dense outlined v-model="v$.name.$model" :error="v$.name.$error" error-message="Name is required." label="Name" />
    </form-modal>
</template>

<script lang="ts">
import { defineComponent, PropType, reactive } from 'vue';
import { required } from '@vuelidate/validators';
import { Platform } from 'src/shared/core/entities/platform.model';
import useVuelidate from '@vuelidate/core';
import FormModal from 'src/shared/components/modals/form-modal/FormModal.vue';

export default defineComponent({
    components: { FormModal },
    emits: ['close', 'save'],
    props: {
        platform: {
            type: Object as PropType<Platform>,
            required: true
        }
    },
    setup(props, { emit }) {
        const platform = reactive<Platform>(props.platform);

        const validationRules = {
            name: { required }
        }

        const v$ = useVuelidate(validationRules, platform);

        async function save() {
            const isValid = await v$.value.$validate();

            if (!isValid) return;

            emit('save', platform);
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
