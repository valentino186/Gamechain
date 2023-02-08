<template>
    <q-page class="q-pa-md">
        <administration-header @create="createNew" />

        <filter-publisher 
            @search="filterPublishers"
            class="q-mt-md">
        </filter-publisher>

        <q-table
            class="q-mt-md"
            title="Publishers"
            :columns="columns"
            :rows="publishers"
            :loading="loading"
            :pagination="initialPagination"
            flat
            bordered
        >
            <template #body-cell-actions="props">
                <q-td auto-width key="actions" :props="props">
                    <q-btn class="q-mr-sm" title="Edit" unelevated round color="deep-orange" icon="edit" size="sm" @click="handleUpdateBtnClick(props.row)" />
                    <q-btn class="q-mr-sm" title="Games" unelevated round color="indigo" icon="videogame_asset" size="sm" @click="handleGamesBtnClick(props.row.id)" />
                    <q-btn unelevated round title="Delete" color="negative" icon="delete" size="sm" @click="handleDeleteBtnClick(props.row)" />
                </q-td>
            </template>
        </q-table>

        <publisher-modal
            v-if="showPublisherModal"
            :publisher="selectedPublisher"
            @save="savePublisher"
            @close="closePublisherModal">
        </publisher-modal>

        <confirmation-modal
            v-if="showConfirmationModal"
            :displayMessage="`Are you sure you want to delete '${selectedPublisher.name}' and all of their games?`"
            @ok="deletePublisher"
            @cancel="closeConfirmationModal">
        </confirmation-modal>
    </q-page>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted, reactive, ref } from "vue";
import { Publisher } from "src/shared/core/entities/publisher.model";
import { usePublisherService } from "src/shared/core/services/publisher.service";
import { usePublisherStore } from "src/stores/publisher.store";
import { PublisherFilterForm } from "src/shared/infrastructure/models/filters/publisher-filter-form.model";

import PublisherModal from "../components/PublisherModal.vue";
import FilterPublisher from "../components/FilterPublisher.vue";
import ConfirmationModal from "src/shared/components/modals/confirmation-modal/ConfirmationModal.vue";
import AdministrationHeader from "src/shared/components/administration-header/AdministrationHeader.vue";
import { useRouter } from "vue-router";

const initialPublisher: Publisher = {
    id: '',
    name: ''
}

export default defineComponent({
    components: { PublisherModal, ConfirmationModal, FilterPublisher, AdministrationHeader },
    setup() {
        const selectedPublisher = reactive<Publisher>({
            id: '',
            name: ''
        });

        const showPublisherModal = ref<boolean>(false);
        const showConfirmationModal = ref<boolean>(false);

        const publisherService = usePublisherService();
        const publisherStore = usePublisherStore();
        const router = useRouter();

        const loading = computed(() => publisherStore.state.loading);
        const publishers = computed(() => publisherStore.getPublishers());

        const columns = [
            { name: 'name', align: 'left', label: 'Name', field: 'name', sortable: true },
            { name: 'actions', align: 'center', label: 'Actions' }
        ];

        const initialPagination = {
            sortBy: 'name'
        };

        onMounted(() => {
            setSelectedPublisher(initialPublisher);
            publisherService.getPublishers();
        })

        function createNew() {
            showPublisherModal.value = true;
        }

        function handleUpdateBtnClick(publisher: Publisher) {
            Object.assign(selectedPublisher, publisher);
            showPublisherModal.value = true;
        }

        function handleGamesBtnClick(publisherId: string) {
            router.push(`/publishers/${publisherId}/games`)
        }

        function handleDeleteBtnClick(publisher: Publisher) {
            setSelectedPublisher(publisher)
            showConfirmationModal.value = true;
        }

        function savePublisher(publisher: Publisher) {
            if (publisher.id)
                updatePublisher(publisher);
            else
                createPublisher(publisher);

            closePublisherModal();
        }

        function createPublisher(publisher: Publisher) {
            publisherService.createPublisher(publisher);
        }

        function updatePublisher(publisher: Publisher) {
            publisherService.updatePublisher(publisher);
        }

        function deletePublisher() {
            publisherService.deletePublisher(selectedPublisher.id);
            closeConfirmationModal();
        }

        function setSelectedPublisher(publisher: Publisher) {
            Object.assign(selectedPublisher, publisher);
        }

        function closePublisherModal() {
            setSelectedPublisher(initialPublisher);
            showPublisherModal.value = false;
        }

        function closeConfirmationModal() {
            setSelectedPublisher(initialPublisher);
            showConfirmationModal.value = false;
        }

        function filterPublishers(filters: PublisherFilterForm) {
            publisherStore.setFilters(filters);
        }

        return {
            columns,
            loading,
            publishers,
            initialPagination,
            createNew,
            handleUpdateBtnClick,
            handleGamesBtnClick,
            handleDeleteBtnClick,
            showConfirmationModal,
            showPublisherModal,
            savePublisher,
            deletePublisher,
            selectedPublisher,
            closePublisherModal,
            closeConfirmationModal,
            filterPublishers
        }
    }
})
</script>