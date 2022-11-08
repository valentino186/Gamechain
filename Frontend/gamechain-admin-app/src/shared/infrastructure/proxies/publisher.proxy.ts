import { UpdatePublisherRequest } from './../models/requests/publisher/update-publisher-request.model';
import { CreatePublisherRequest } from './../models/requests/publisher/create-publisher-request.model';
import { PublisherResponse } from './../models/responses/publisher-response.model';
import { authGamechainApi } from "src/boot/axios"

const url = '/Publisher';

export const usePublisherProxy = () => {
    function getPublishers() {
        return authGamechainApi.get<PublisherResponse[]>(url);
    }

    function createPublisher(createPublisherRequest: CreatePublisherRequest) {
        return authGamechainApi.post<PublisherResponse>(url, createPublisherRequest);
    }

    function updatePublisher(publisherId: string, updatePublisherRequest: UpdatePublisherRequest) {
        return authGamechainApi.put<PublisherResponse>(`${url}/${publisherId}`, updatePublisherRequest);
    }

    function deletePublisher(publisherId: string) {
        return authGamechainApi.delete(`${url}/${publisherId}`);
    }

    return {
        getPublishers,
        createPublisher,
        updatePublisher,
        deletePublisher
    }
}