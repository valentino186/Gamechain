<template>
    <q-page class="q-pa-md">
        <administration-header @create="createNew" />

        <filter-feature
            @search="filterFeatures"
            class="q-mt-md">
        </filter-feature>
    </q-page>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

import AdministrationHeader from 'src/shared/components/administration-header/AdministrationHeader.vue';
import FilterFeature from '../components/FilterFeature.vue';

export default defineComponent({
    components: { AdministrationHeader, FilterFeature },
    setup() {
        function createNew() {

        }

        function filterFeatures() {

        }

        return {
            createNew,
            filterFeatures
        }
    }
})
</script>
