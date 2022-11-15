import { Publisher } from './../shared/core/entities/publisher.model';
import { defineStore } from 'pinia';
import { reactive } from 'vue';
import { PublisherFilterForm } from 'src/shared/infrastructure/models/filters/publisher-filter-form.model';

interface PublisherState {
    publishers: Publisher[];
    loading: boolean;
    filters: PublisherFilterForm;
}

export const usePublisherStore = defineStore('publishers', () => {
    const state = reactive<PublisherState>({
        publishers: [],
        loading: false,
        filters: {
            name: ''
        }
    })

    function getPublishers() {
        return state.publishers.filter(x => x.name.toLowerCase().includes(state.filters.name.toLowerCase()));
    }
    
    function setLoading(status: boolean) {
        state.loading = status;
    }
    
    function setPublishers(publishers: Publisher[]) {
        state.publishers = publishers;
    }

    function setFilters(publisherFilterForm: PublisherFilterForm) {
        state.filters = publisherFilterForm;
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
        deletePublisher,
        setFilters
    }
})