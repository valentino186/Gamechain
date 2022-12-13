import PublishersPage from 'src/features/publisher/pages/PublishersPage.vue';
import { RouteRecordRaw } from "vue-router";

export const publisherRoutes: RouteRecordRaw[] = [
    {
        path: "publishers",
        component: PublishersPage
    }
]