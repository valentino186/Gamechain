<template>
    <form-dialog @save="save">
        <q-input class="full-width" outlined v-model="formData.name" label="Name" />
    </form-dialog>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import FormDialog from 'src/shared/components/modal-dialogs/form-dialog/FormDialog.vue';
import { CreatePublisherRequest } from 'src/shared/infrastructure/models/requests/publisher/create-publisher-request.model';

export default defineComponent({
    components: { FormDialog },
    emits: ['save'],
    setup(_, { emit }) {
        const formData = reactive({
            name: ''
        })

        function save() {
            const createPublisherRequest: CreatePublisherRequest = {
                name: formData.name
            }

            emit('save', createPublisherRequest);
        }

        return {
            formData,
            save
        }
    }
})
</script>
