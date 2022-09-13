import { defineStore } from 'pinia';
import { reactive } from 'vue';

export const usePublisherStore = defineStore('publishers', () => {
    const state = reactive({
        loading: false
    })

    function setLoading(status: boolean) {
        state.loading = status;
    }

    return {
        state,
        setLoading
    }
})