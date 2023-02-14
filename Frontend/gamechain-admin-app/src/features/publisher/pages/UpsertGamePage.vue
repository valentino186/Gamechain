<template>
    <q-page class="q-pa-md">
        <q-card flat bordered class="my-card">
            <q-card-section>
                <div class="text-h6">Game</div>
            </q-card-section>

            <q-separator inset />

            <q-card-section>
                <q-card flat bordered class="my-card">
                    <q-card-section class="bg-grey-9 text-white">
                        <div class="text-h6">General information</div>
                    </q-card-section>

                    <q-separator inset />

                    <q-card-section>
                        <div class="row">
                            <q-input class="col-6" type="number" dense outlined label="Name" />
                        </div>
                        <div class="row q-mt-md">
                            <q-input class="col-6" type="number" dense outlined label="Price">
                                <template v-slot:append>
                                    <q-icon name="euro_symbol" />
                                </template>
                            </q-input>
                        </div>
                        <div class="row q-mt-md">
                            <q-input class="col-6" dense outlined label="Discount">
                                <template v-slot:append>
                                    <q-icon name="percent" />
                                </template>
                            </q-input>
                        </div>
                        <div class="row q-mt-md">
                            <q-input class="col-6" type="textarea" dense outlined label="Description" />
                        </div>
                    </q-card-section>
                </q-card>

                <q-card flat bordered class="q-mt-md my-card">
                    <q-card-section class="bg-grey-9 text-white">
                        <div class="text-h6">Features</div>
                    </q-card-section>

                    <q-separator inset />

                    <q-card-section class="row">
                        <q-checkbox class="col-3" v-model="selectedFeatures" v-for="feature in features" :key="feature.id" :val="feature.id" :label="feature.name" />
                    </q-card-section>
                </q-card>

                <q-card flat bordered class="q-mt-md my-card">
                    <q-card-section class="bg-grey-9 text-white">
                        <div class="text-h6">Genres</div>
                    </q-card-section>

                    <q-separator inset />

                    <q-card-section class="row">
                        <q-checkbox class="col-3" v-model="selectedGenres" v-for="genre in genres" :key="genre.id" :val="genre.id" :label="genre.name" />
                    </q-card-section>
                </q-card>

                <q-card flat bordered class="q-mt-md my-card">
                    <q-card-section class="bg-grey-9 text-white">
                        <div class="text-h6">Platforms</div>
                    </q-card-section>


                    <q-separator inset />

                    <q-card-section class="row">
                        <q-checkbox class="col-3" v-model="selectedPlatforms" v-for="platform in platforms" :key="platform.id" :val="platform.id" :label="platform.name" />
                    </q-card-section>
                </q-card>
            </q-card-section>

            <q-separator inset />

            <q-card-section class="row justify-end">
                <q-btn class="col-3" @click="handleSaveBtnClick" unelevated color="primary" size="md" label="Save" />
            </q-card-section>
        </q-card>
    </q-page>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted, ref } from 'vue';
import { useFeatureService } from 'src/shared/core/services/feature.service';
import { useGenreService } from 'src/shared/core/services/genre.service';
import { usePlatformService } from 'src/shared/core/services/platform.service';
import { useFeatureStore } from 'src/stores/feature.store';
import { useGenreStore } from 'src/stores/genre.store';
import { usePlatformStore } from 'src/stores/platform.store';

export default defineComponent({
    setup() {
        const featureService = useFeatureService();
        const featureStore = useFeatureStore();

        const genreService = useGenreService();
        const genreStore = useGenreStore();

        const platformService = usePlatformService();
        const platformStore = usePlatformStore();

        const features = computed(() => featureStore.getFeatures());
        const genres = computed(() => genreStore.getGenres());
        const platforms = computed(() => platformStore.getPlatforms());

        const selectedFeatures = ref([]);
        const selectedGenres = ref([]);
        const selectedPlatforms = ref([]);

        onMounted(() => {
            featureService.getFeatures();
            genreService.getGenres();
            platformService.getPlatforms();
        })

        function handleSaveBtnClick() {

        }

        return {
            features,
            genres,
            platforms,
            selectedFeatures,
            selectedGenres,
            selectedPlatforms,
            handleSaveBtnClick
        }
    }
})
</script>
