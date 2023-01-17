import FeaturesPage from 'src/features/feature/pages/FeaturesPage.vue';
import { RouteRecordRaw } from "vue-router";

export const featureRoutes: RouteRecordRaw[] = [
    {
        path: "/features",
        component: FeaturesPage
    }
]