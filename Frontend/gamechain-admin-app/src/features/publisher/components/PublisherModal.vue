<template>
    <form-dialog @save="save">
        <q-input class="full-width" outlined v-model="publisher.name" label="Name" />
    </form-dialog>
</template>

<script lang="ts">
import { defineComponent, PropType } from 'vue';
import FormDialog from 'src/shared/components/modal-dialogs/form-dialog/FormDialog.vue';
import { Publisher } from 'src/shared/core/entities/publisher.model';

export default defineComponent({
    components: { FormDialog },
    emits: ['save'],
    props: {
        publisher: {
            type: Object as PropType<Publisher>,
            required: true
        }
    },
    setup(props, { emit }) {
        const publisher = props.publisher;

        function save() {
            emit('save', publisher);
        }

        return {
            publisher,
            save
        }
    }
})
</script>
