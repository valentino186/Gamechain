import { reactive } from 'vue';
import { defineStore } from 'pinia';
import { Platform } from './../shared/core/entities/platform.model';

interface PlatformState {
    platforms: Platform[];
    loading: boolean;
    // filters: PlatformFilterForm;
}

export const usePlatformStore = defineStore('platforms', () => {
    const state = reactive<PlatformState>({
        platforms: [],
        loading: false
    });

    function setPlatforms(platforms: Platform[]) {
        state.platforms = platforms;
    }

    function setLoading(status: boolean) {
        state.loading = status;
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
        setPlatforms,
        setLoading,
        createPlatform,
        updatePlatform,
        deletePlatform
    }
})