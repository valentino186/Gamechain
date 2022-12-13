<template>
    <q-page class="q-pa-md">
        <q-card flat bordered class="my-card">
            <q-card-section>
                <q-btn @click="handleCreateNewBtnClick" unelevated color="primary" size="md" label="Create New" />
            </q-card-section>
        </q-card>

        <filter-platform
            @search="filterPlatforms"
            class="q-mt-md">
        </filter-platform>

        <q-table
            class="q-mt-md"
            title="Platforms"
            :columns="columns"
            :rows="platforms"
            :loading="loading"
            :pagination="initialPagination"
            flat
            bordered
        >
            <template #body-cell-actions="props">
                <q-td auto-width key="actions" :props="props">
                    <q-btn class="q-mr-sm" unelevated round color="deep-orange" icon="edit" size="sm" @click="handleUpdateBtnClick(props.row)" />
                    <q-btn unelevated round color="negative" icon="delete" size="sm" @click="handleDeleteBtnClick(props.row)" />
                </q-td>
            </template>
        </q-table>

        <platform-modal
            v-if="showPlatformModal"
            :platform="selectedPlatform"
            @save="savePlatform"
            @close="closePlatformModal">
        </platform-modal>

        <confirmation-modal
            v-if="showConfirmationModal"
            :displayMessage="`Are you sure you want to delete '${selectedPlatform.name}'?`"
            @ok="deletePlatform"
            @cancel="closeConfirmationModal">
        </confirmation-modal>
    </q-page>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted, reactive, ref } from 'vue';
import { usePlatformStore } from 'src/stores/platform.store';
import { usePlatformService } from 'src/shared/core/services/platform.service';
import { Platform } from 'src/shared/core/entities/platform.model';

import FilterPlatform from '../components/FilterPlatform.vue';
import PlatformModal from '../components/PlatformModal.vue';
import ConfirmationModal from "src/shared/components/modals/confirmation-modal/ConfirmationModal.vue";
import { PlatformFilterForm } from 'src/shared/infrastructure/models/filters/platform-filter.form.model';

const initialPlatform: Platform = {
    id: '',
    name: ''
}

export default defineComponent({
    components: { FilterPlatform, PlatformModal, ConfirmationModal },
    setup() {
        const selectedPlatform = reactive<Platform>({
            id: '',
            name: ''
        })
        const showPlatformModal = ref<boolean>(false);
        const showConfirmationModal = ref<boolean>(false);

        const platformStore = usePlatformStore();
        const platformService = usePlatformService();

        const platforms = computed(() => platformStore.getPlatforms());
        const loading = computed(() => platformStore.state.loading);

        const columns = [
            { name: 'name', align: 'left', label: 'Name', field: 'name', sortable: true },
            { name: 'actions', align: 'center', label: 'Actions' }
        ];

        const initialPagination = {
            sortBy: 'name'
        }

        onMounted(() => {
            setSelectedPlatform(initialPlatform);
            platformService.getPlatforms();
        })

        function handleCreateNewBtnClick() {
            showPlatformModal.value = true;
        }

        function handleUpdateBtnClick(platform: Platform) {
            setSelectedPlatform(platform);
            showPlatformModal.value = true;
        }

        function handleDeleteBtnClick(platform: Platform) {
            setSelectedPlatform(platform);
            showConfirmationModal.value = true;
        }

        function filterPlatforms(platformFilterForm: PlatformFilterForm) {
            platformStore.setFilters(platformFilterForm);
        }

        function savePlatform(platform: Platform) {
            if (platform.id)
                updatePlatform(platform);
            else
                createPlatform(platform);
            
            closePlatformModal();
        }

        function createPlatform(platform: Platform) {
            platformService.createPlatform(platform);
        }

        function updatePlatform(platform: Platform) {
            platformService.updatePlatform(platform);
        }

        function deletePlatform() {
            platformService.deletePlatform(selectedPlatform.id);
            closeConfirmationModal();
        }

        function closeConfirmationModal() {
            showConfirmationModal.value = false;
            setSelectedPlatform(initialPlatform);
        }

        function closePlatformModal() {
            setSelectedPlatform(initialPlatform);
            showPlatformModal.value = false;
        }

        function setSelectedPlatform(platform: Platform) {
            Object.assign(selectedPlatform, platform);
        }

        return {
            selectedPlatform,
            showPlatformModal,
            showConfirmationModal,
            platforms,
            loading,
            columns,
            initialPagination,
            handleCreateNewBtnClick,
            handleUpdateBtnClick,
            handleDeleteBtnClick,
            filterPlatforms,
            savePlatform,
            deletePlatform,
            closeConfirmationModal,
            closePlatformModal
        }
    }
})
</script>
