import GenresPage from 'src/features/genre/pages/GenresPage.vue';
import { RouteRecordRaw } from "vue-router";

export const genreRoutes: RouteRecordRaw[] = [
    {
        path: "/genres",
        component: GenresPage
    }
]