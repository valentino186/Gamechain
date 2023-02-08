<template>
    <q-page class="q-pa-md">
        <administration-header @create="createNew" />

        <filter-feature
            @search="filterFeatures"
            class="q-mt-md">
        </filter-feature>

        <q-table
            class="q-mt-md"
            title="Features"
            :columns="columns"
            :rows="features"
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

        <feature-modal
            v-if="showFeatureModal"
            :feature="selectedFeature"
            @save="saveFeature"
            @close="closeFeatureModal">
        </feature-modal>

        <confirmation-modal
            v-if="showConfirmationModal"
            :displayMessage="`Are you sure you want to delete '${selectedFeature.name}'?`"
            @ok="deleteFeature"
            @cancel="closeConfirmationModal">
        </confirmation-modal>
    </q-page>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted, reactive, ref } from 'vue';
import { Feature } from 'src/shared/core/entities/feature.model';
import { FeatureFilterForm } from 'src/shared/infrastructure/models/filters/feature-filter-form.model';

import AdministrationHeader from 'src/shared/components/administration-header/AdministrationHeader.vue';
import ConfirmationModal from 'src/shared/components/modals/confirmation-modal/ConfirmationModal.vue';
import FilterFeature from '../components/FilterFeature.vue';
import FeatureModal from '../components/FeatureModal.vue';

import { useFeatureService } from 'src/shared/core/services/feature.service';
import { useFeatureStore } from 'src/stores/feature.store';

const initialFeature: Feature = {
    id: '',
    name: ''
}

export default defineComponent({
    components: { AdministrationHeader, ConfirmationModal, FilterFeature, FeatureModal },
    setup() {
        const selectedFeature = reactive<Feature>({
            id: '',
            name: ''
        });

        const showFeatureModal = ref<boolean>(false);
        const showConfirmationModal = ref<boolean>(false);
        
        const featureService = useFeatureService();
        const featureStore = useFeatureStore();

        const columns = [
            { name: 'name', align: 'left', label: 'Name', field: 'name', sortable: true },
            { name: 'actions', align: 'center', label: 'Actions' }
        ];

        const initialPagination = {
            sortBy: 'name'
        }

        const features = computed(() => featureStore.getFeatures());
        const loading = computed(() => featureStore.state.loading);

        onMounted(() => {
            setSelectedFeature(initialFeature);
            featureService.getFeatures();
        })

        function createNew() {
            showFeatureModal.value = true;
        }

        function filterFeatures(featureFilterForm: FeatureFilterForm) {
            featureStore.setFilters(featureFilterForm);
        }

        function handleUpdateBtnClick(feature: Feature) {
            setSelectedFeature(feature);
            showFeatureModal.value = true;
        }

        function handleDeleteBtnClick(feature: Feature) {
            setSelectedFeature(feature);
            showConfirmationModal.value = true;
        }

        function saveFeature(feature: Feature) {
            if (selectedFeature.id)
                updateFeature(feature);
            else
                createFeature(feature);

            closeFeatureModal();
        }

        function createFeature(feature: Feature) {
            featureService.createFeature(feature);
        }

        function updateFeature(feature: Feature) {
            featureService.updateFeature(feature);
        }

        function deleteFeature() {
            featureService.deleteFeature(selectedFeature.id);
            closeConfirmationModal();
        }

        function closeFeatureModal() {
            showFeatureModal.value = false;
            setSelectedFeature(initialFeature);
        }

        function closeConfirmationModal() {
            showConfirmationModal.value = true;
            setSelectedFeature(initialFeature);
        }

        function setSelectedFeature(feature: Feature) {
            Object.assign(selectedFeature, feature);
        }

        return {
            selectedFeature,
            showFeatureModal,
            showConfirmationModal,
            columns,
            initialPagination,
            features,
            loading,
            createNew,
            filterFeatures,
            handleUpdateBtnClick,
            handleDeleteBtnClick,
            saveFeature,
            deleteFeature,
            closeFeatureModal,
            closeConfirmationModal
        }
    }
})
</script>
