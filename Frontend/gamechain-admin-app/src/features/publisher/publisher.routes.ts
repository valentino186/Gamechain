import { RouteRecordRaw } from "vue-router";
import PublishersPage from 'src/features/publisher/pages/PublishersPage.vue';
import PublisherGamesPage from 'src/features/publisher/pages/PublisherGamesPage.vue';
import UpsertGamePage from 'src/features/publisher/pages/UpsertGamePage.vue';

export const publisherRoutes: RouteRecordRaw[] = [
    {
        path: "/publishers",
        component: PublishersPage
    },
    {
        path: "/publishers/:publisherId/games",
        component: PublisherGamesPage
    },
    {
        path: "/publishers/:publisherId/games/upsert",
        component: UpsertGamePage
    }
]