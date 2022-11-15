<template>
    <form-modal 
        headerText="Publisher"
        @close="close" 
        @save="save"
    >
        <q-input class="full-width" outlined v-model="v$.name.$model" :error="v$.name.$error" error-message="Name is required." label="Name" />
    </form-modal>
</template>

<script lang="ts">
import { defineComponent, PropType, reactive } from 'vue';
import { required } from '@vuelidate/validators';
import { Publisher } from 'src/shared/core/entities/publisher.model';
import useVuelidate from '@vuelidate/core';
import FormModal from 'src/shared/components/modals/form-modal/FormModal.vue';

export default defineComponent({
    components: { FormModal },
    emits: ['close', 'save'],
    props: {
        publisher: {
            type: Object as PropType<Publisher>,
            required: true
        }
    },
    setup(props, { emit }) {
        const publisher = reactive<Publisher>(props.publisher);

        const validationRules = {
            name: { required }
        }

        const v$ = useVuelidate(validationRules, publisher);

        async function save() {
            const isValid = await v$.value.$validate();

            if (!isValid) return;

            emit('save', publisher);
        }

        function close() {
            emit('close');
        }

        return {
            v$,
            publisher,
            save,
            close
        }
    }
})
</script>
