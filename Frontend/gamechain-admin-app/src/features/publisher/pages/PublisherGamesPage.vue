<template>
    <q-page class="q-pa-md">
        <div v-if="!publisherLoading">
            <q-card flat bordered class="my-card">
                <q-card-section>
                    <div class="text-h6">{{ publisher?.name }}</div>
                </q-card-section>

                <q-separator inset />

                <q-card-section>
                    <div class="row">
                        <div class="col column text-center">
                            <span class="text-h6">Total games</span>
                            <span class="text-subtitle1">0</span>
                        </div>
                        <div class="col column text-center">
                            <span class="text-h6">Copies sold</span>
                            <span class="text-subtitle1">0</span>
                        </div>
                        <div class="col column text-center">
                            <span class="text-h6">Total revenue</span>
                            <span class="text-subtitle1">0 $</span>
                        </div>
                    </div>
                </q-card-section>
            </q-card>

            <q-card flat bordered class="my-card q-mt-md">
                <q-card-section>
                    <div class="text-h6">Games</div>
                </q-card-section>

                <q-separator inset />

                <q-card-section>
                    <q-btn @click="handleCreateNewBtnClick" unelevated color="primary" size="md" label="Create New" />
                </q-card-section>

                <q-separator inset />

                <q-card-section>
                    <q-table
                        :columns="columns"
                        :rows="publishers"
                        :loading="gamesLoading"
                        :pagination="initialPagination"
                        flat
                        bordered
                    >
                        <template #body-cell-actions="props">
                            <q-td auto-width key="actions" :props="props">
                                <q-btn class="q-mr-sm" title="Edit" unelevated round color="deep-orange" icon="edit" size="sm" @click="handleUpdateBtnClick(props.row)" />
                                <q-btn unelevated round title="Delete" color="negative" icon="delete" size="sm" @click="handleDeleteBtnClick(props.row)" />
                            </q-td>
                        </template>
                    </q-table>
                </q-card-section>
            </q-card>
        </div>
    </q-page>
</template>

<script lang="ts">
import { usePublisherService } from "src/shared/core/services/publisher.service";
import { usePublisherStore } from "src/stores/publisher.store";
import { useGameService } from "src/shared/core/services/game.service";
import { computed, defineComponent, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { useGameStore } from "src/stores/game.store";

export default defineComponent({
    setup() {
        const publisherService = usePublisherService();
        const publisherStore = usePublisherStore();

        const gameService = useGameService();
        const gameStore = useGameStore();

        const route = useRoute();
        const router = useRouter();

        const publisherId = route.params.publisherId as string;

        const publisher = computed(() => publisherStore.state.publisher);
        const publisherLoading = computed(() => publisherStore.state.loading);

        const games = computed(() => gameStore.state.games);
        const gamesLoading = computed(() => gameStore.state.loading);

        const columns = [
            { name: 'name', align: 'left', label: 'Name', field: 'name', sortable: true },
            { name: 'price', align: 'left', label: 'Price', field: 'price', sortable: true },
            { name: 'discount', align: 'left', label: 'Discount', field: 'discount', sortable: true },
            { name: 'actions', align: 'center', label: 'Actions' }
        ];

        const initialPagination = {
            sortBy: 'name'
        };

        onMounted(() => {
            publisherService.getPublisherById(publisherId);
            gameService.getPublisherGames(publisherId);
        })

        function handleCreateNewBtnClick() {
            router.push(`/publishers/${publisherId}/games/upsert`)
        }

        function handleUpdateBtnClick() {

        }

        function handleDeleteBtnClick() {

        }

        return {
            columns,
            initialPagination,
            publisher,
            publisherLoading,
            games,
            gamesLoading,
            handleCreateNewBtnClick
        }
    }
})
</script>