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
        deletePublisher
    }
}