import { reactive } from 'vue';
import { defineStore } from 'pinia';
import { Platform } from './../shared/core/entities/platform.model';
import { PlatformFilterForm } from './../shared/infrastructure/models/filters/platform-filter.form.model';

interface PlatformState {
    platforms: Platform[];
    loading: boolean;
    filters: PlatformFilterForm;
}

export const usePlatformStore = defineStore('platforms', () => {
    const state = reactive<PlatformState>({
        platforms: [],
        loading: false,
        filters: {
            name: ''
        }
    });

    function getPlatforms() {
        return state.platforms.filter(x => x.name.toLowerCase().includes(state.filters.name.toLowerCase()));
    }

    function setLoading(status: boolean) {
        state.loading = status;
    }

    function setPlatforms(platforms: Platform[]) {
        state.platforms = platforms;
    }

    function setFilters(platformFilterForm: PlatformFilterForm) {
        Object.assign(state.filters, platformFilterForm);
    }

    function createPlatform(platform: Platform) {
        state.platforms.push(platform);
    }

    function updatePlatform(platform: Platform) {
        const platformIndex = state.platforms.findIndex(x => x.id === platform.id);
        state.platforms[platformIndex] = platform;
    }

    function deletePlatform(platformId: string) {
        state.platforms = state.platforms.filter(x => x.id !== platformId);
    }

    return {
        state,
        getPlatforms,
        setLoading,
        setPlatforms,
        setFilters,
        createPlatform,
        updatePlatform,
        deletePlatform
    }
})