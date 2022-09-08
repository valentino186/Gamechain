import { RouteRecordRaw } from "vue-router";
import { checkToken } from "./guards/login.guard";
import LoginPage from "src/features/login/pages/LoginPage.vue"

export const loginRoutes: RouteRecordRaw[] = [
    {
        path: "/login",
        component: LoginPage,
        beforeEnter: checkToken
    }
]