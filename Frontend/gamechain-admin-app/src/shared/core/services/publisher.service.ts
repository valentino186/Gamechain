import { useNotify } from './../../components/notify/useNotify';
import { UpdatePublisherCommand } from '../../infrastructure/models/requests/publisher/update-publisher-command.model';
import { CreatePublisherCommand } from 'src/shared/infrastructure/models/requests/publisher/create-publisher-command.model';
import { usePublisherStore } from './../../../stores/publisher.store';
import { usePublisherProxy } from './../../infrastructure/proxies/publisher.proxy';

export const usePublisherService = () => {
    const publisherProxy = usePublisherProxy();
    const publisherStore = usePublisherStore();
    const notify = useNotify();

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

    async function createPublisher(createPublisherRequest: CreatePublisherCommand) {
        try {
            publisherStore.setLoading(true);

            const response = await publisherProxy.createPublisher(createPublisherRequest);

            publisherStore.createPublisher(response.data);

            notify.success('Publisher created successfully!');
        }
        catch (error) {
            notify.negative('An error has occured while trying to save data.');
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    async function updatePublisher(updatePublisherRequest: UpdatePublisherCommand) {
        try {
            publisherStore.setLoading(true);

            const response = await publisherProxy.updatePublisher(updatePublisherRequest);

            publisherStore.updatePublisher(response.data);

            notify.success('Publisher updated successfully!');
        }
        catch (error) {
            notify.negative('An error has occured while trying to save data.');
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

            notify.success('Publisher deleted successfully!');
        }
        catch (error) {
            notify.negative('An error has occured while trying to delete data.');
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