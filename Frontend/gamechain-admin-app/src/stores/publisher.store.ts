import { Publisher } from './../shared/core/entities/publisher.model';
import { defineStore } from 'pinia';
import { reactive } from 'vue';

interface PublisherState {
    publishers: Publisher[];
    loading: boolean;
}

export const usePublisherStore = defineStore('publishers', () => {
    const state = reactive<PublisherState>({
        publishers: [],
        loading: false
    })

    function getPublishers() {
        return state.publishers;
    }
    
    function setLoading(status: boolean) {
        state.loading = status;
    }
    
    function setPublishers(publishers: Publisher[]) {
        state.publishers = publishers;
    }

    function createPublisher(publisher: Publisher) {
        state.publishers.push(publisher);
    }

    function updatePublisher(publisher: Publisher) {
        const publisherIndex = state.publishers.findIndex(x => x.id === publisher.id);
        state.publishers[publisherIndex] = { ...publisher };
    }

    function deletePublisher(publisherId: string) {
        state.publishers = state.publishers.filter(x => x.id !== publisherId);
    }

    return {
        state,
        getPublishers,
        setLoading,
        setPublishers,
        createPublisher,
        updatePublisher,
        deletePublisher
    }
})