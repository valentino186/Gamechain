<template>
    <form-modal 
        headerText="Genre"
        @close="close" 
        @save="save"
    >
        <q-input class="full-width" dense outlined v-model="v$.name.$model" :error="v$.name.$error" error-message="Name is required." label="Name" />
    </form-modal>
</template>

<script lang="ts">
import { defineComponent, PropType, reactive } from 'vue';
import { required } from '@vuelidate/validators';
import { Genre } from 'src/shared/core/entities/genre.model';

import useVuelidate from '@vuelidate/core';

import FormModal from 'src/shared/components/modals/form-modal/FormModal.vue';

export default defineComponent({
    components: { FormModal },
    emits: ['close', 'save'],
    props: {
        genre: {
            type: Object as PropType<Genre>,
            required: true
        }
    },
    setup(props, { emit }) {
        const genre = reactive<Genre>(props.genre);

        const validationRules = {
            name: { required }
        }

        const v$ = useVuelidate(validationRules, genre);

        async function save() {
            const isValid = await v$.value.$validate();

            if (!isValid) return;

            emit('save', genre);
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
