

<template>
    <q-page class="q-pa-md">
        {{ publishers }}
    </q-page>
</template>

<script lang="ts">
import { useRepo } from "pinia-orm";
import { Publisher } from "src/shared/core/entities/publisher.model";
import { usePublisherService } from "src/shared/core/services/publisher.service";
import { computed, defineComponent, onMounted } from "vue";

export default defineComponent({
    setup() {
        const publisherService = usePublisherService();

        onMounted(() => {
            publisherService.getPublishers();
        })

        const publishers = computed(() => {
            return useRepo(Publisher).all();
        })

        return {
            publishers
        }
    }
})
</script>