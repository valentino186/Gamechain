import { PublisherResponse } from './../models/responses/publisher-response.model';
import { authGamechainApi } from "src/boot/axios"

export const usePublisherProxy = () => {
    function getPublishers() {
        return authGamechainApi.get<PublisherResponse[]>('/Publisher');
    }

    function deletePublisher(publisherId: string) {
        return authGamechainApi.delete(`/Publisher/${publisherId}`);
    }

    return {
        getPublishers,
        deletePublisher
    }
}