<template>
    <q-page class="q-pa-md">
        <q-card flat bordered class="my-card">
            <q-card-section>
                <q-btn @click="handleCreateNewBtnClick" unelevated color="primary" size="md" label="Create New" />
            </q-card-section>
        </q-card>

        <filter-platform
            @search="filterPlatforms"
            class="q-mt-md">
        </filter-platform>
    </q-page>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import FilterPlatform from '../components/FilterPlatform.vue';

export default defineComponent({
    components: { FilterPlatform },
    setup() {
        function handleCreateNewBtnClick() {

        }

        function filterPlatforms() {

        }

        return {
            handleCreateNewBtnClick,
            filterPlatforms
        }
    }
})
</script>
