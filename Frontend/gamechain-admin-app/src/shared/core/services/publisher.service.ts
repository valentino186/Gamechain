import { UpdatePublisherRequest } from './../../infrastructure/models/requests/publisher/update-publisher-request.model';
import { CreatePublisherRequest } from 'src/shared/infrastructure/models/requests/publisher/create-publisher-request.model';
import { usePublisherStore } from './../../../stores/publisher.store';
import { usePublisherProxy } from './../../infrastructure/proxies/publisher.proxy';

export const usePublisherService = () => {
    const publisherProxy = usePublisherProxy();
    const publisherStore = usePublisherStore();

    async function getPublishers() {
        try {
            publisherStore.setLoading(true);
    
            const response = await publisherProxy.getPublishers();

            publisherStore.setPublishers(response.data);
        }
        catch (error) {
            console.error(error)
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    async function createPublisher(createPublisherRequest: CreatePublisherRequest) {
        try {
            publisherStore.setLoading(true);

            const response = await publisherProxy.createPublisher(createPublisherRequest);

            publisherStore.createPublisher(response.data);
        }
        catch (error) {
            console.error(error);
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    async function updatePublisher(publisherId: string, updatePublisherRequest: UpdatePublisherRequest) {
        try {
            publisherStore.setLoading(true);

            const response = await publisherProxy.updatePublisher(publisherId, updatePublisherRequest);

            publisherStore.updatePublisher(response.data);
        }
        catch (error) {
            console.error(error);
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    async function deletePublisher(publisherId: string) {
        try {
            publisherStore.setLoading(true);

            await publisherProxy.deletePublisher(publisherId);

            publisherStore.deletePublisher(publisherId);
        }
        catch (error) {
            console.error(error)
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    return {
        getPublishers,
        createPublisher,
        updatePublisher,
        deletePublisher
    }
}