import { FeatureFilterForm } from './../shared/infrastructure/models/filters/feature-filter-form.model';
import { Feature } from './../shared/core/entities/feature.model';
import { defineStore } from 'pinia';
import { reactive } from 'vue';

interface FeatureState {
    features: Feature[];
    loading: boolean;
    filters: FeatureFilterForm
}

export const useFeatureStore = defineStore('features', () => {
    const state = reactive<FeatureState>({
        features: [],
        loading: false,
        filters: {
            name: ''
        }
    });

    function getFeatures() {
        return state.features.filter(x => x.name.toLowerCase().includes(state.filters.name.toLowerCase()));
    }

    function setFeatures(features: Feature[]) {
        state.features = features;
    }

    function setLoading(status: boolean) {
        state.loading = status;
    }

    function setFilters(featureFilterForm: FeatureFilterForm) {
        Object.assign(state.filters, featureFilterForm);
    }

    function createFeature(feature: Feature) {
        state.features.push(feature);
    }

    function updateFeature(feature: Feature) {
        const featureIndex = state.features.findIndex(x => x.id === feature.id);
        state.features[featureIndex] = feature;
    }

    function deleteFeature(featureId: string) {
        state.features = state.features.filter(x => x.id !== featureId);
    }

    return {
        state,
        getFeatures,
        setFeatures,
        setLoading,
        setFilters,
        createFeature,
        updateFeature,
        deleteFeature
    }
})