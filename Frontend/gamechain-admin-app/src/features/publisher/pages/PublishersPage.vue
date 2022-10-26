<template>
    <q-page class="q-pa-md">
        <q-card flat bordered class="my-card">
            <q-card-section>
                <q-btn @click="handleCreateNewBtnClick" unelevated color="primary" size="md" label="Create New" />
            </q-card-section>
        </q-card>

        <q-table
            class="q-mt-md"
            title="Publishers"
            :columns="columns"
            :rows="publishers"
            :loading="loading"
            flat
            bordered
        >
            <template #body-cell-actions="props">
                <q-td auto-width key="actions" :props="props">
                    <q-btn unelevated round color="negative" icon="delete" size="sm" @click="handleDeleteBtnClick(props.row.id)" />
                </q-td>
            </template>
        </q-table>

        <publisher-modal 
            v-if="showPublisherModal"
            @save="savePublisher" />
    </q-page>
</template>

<script lang="ts">
import { usePublisherService } from "src/shared/core/services/publisher.service";
import { usePublisherStore } from "src/stores/publisher.store";
import { computed, defineComponent, onMounted, ref } from "vue";
import PublisherModal from "../components/PublisherModal.vue";

export default defineComponent({
    components: { PublisherModal },
    setup() {
        const showPublisherModal = ref<boolean>(false);

        const publisherService = usePublisherService();
        const publisherStore = usePublisherStore();

        const columns = [
            { name: 'name', align: 'left', label: 'Name', field: 'name', sortable: true },
            { name: 'actions', align: 'center', label: 'Actions' }
        ];

        const loading = computed(() => publisherStore.state.loading);

        const publishers = computed(() => publisherStore.getPublishers());

        function handleCreateNewBtnClick() {
            showPublisherModal.value = true;
        }

        function handleDeleteBtnClick(publisherId: string) {
            publisherService.deletePublisher(publisherId);
        }

        function savePublisher() {

        }

        onMounted(() => {
            publisherService.getPublishers();
        })

        return {
            columns,
            loading,
            publishers,
            handleCreateNewBtnClick,
            handleDeleteBtnClick,
            showPublisherModal,
            savePublisher
        }
    }
})
</script>