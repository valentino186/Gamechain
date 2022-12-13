import PlatformsPage from 'src/features/platform/pages/PlatformsPage.vue';
import { RouteRecordRaw } from "vue-router";

export const platformRoutes: RouteRecordRaw[] = [
    {
        path: "/platforms",
        component: PlatformsPage
    }
]