import { useRepo } from 'pinia-orm';
import { Publisher } from './../entities/publisher.model';
import { usePublisherStore } from './../../../stores/publisher.store';
import { usePublisherProxy } from './../../infrastructure/proxies/publisher.proxy';

export const usePublisherService = () => {
    const publisherProxy = usePublisherProxy();
    const publisherStore = usePublisherStore();
    const publisherRepo = useRepo(Publisher)

    async function getPublishers() {
        try {
            publisherStore.setLoading(true);
    
            const response = await publisherProxy.getPublishers();
    
            publisherRepo.insert(response.data);
        }
        catch (error) {
            console.log(error)
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    return {
        getPublishers
    }
}