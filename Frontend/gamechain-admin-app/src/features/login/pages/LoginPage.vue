<template>
    <q-layout>
        <q-page-container>
            <q-page class="flex justify-center items-center">
                <q-card class="my-card" bordered style="max-width: 400px; width: 90%;">
                    <q-card-section class="text-center">
                        <span class="text-h5 text-indigo-8 text-weight-bold">Gamechain Admin</span>
                    </q-card-section>

                    <q-separator inset />

                    <q-card-section>
                        <q-input v-model="loginRequest.userName" outlined label="Username" class="q-mb-md">
                            <template v-slot:prepend>
                                <q-icon name="person" color="indigo-6" />
                            </template>
                            <template v-slot:append>
                                <q-icon name="event" color="indigo-6" />
                            </template>
                        </q-input>

                        <q-input v-model="loginRequest.password" outlined label="Password" :type="showPassword ? 'text' : 'password'">
                            <template v-slot:prepend>
                                <q-icon name="key" color="indigo-6" />
                            </template>
                            <template v-slot:append>
                                <q-icon
                                    :name="showPassword ? 'visibility' : 'visibility_off'"
                                    color="indigo-6"
                                    class="cursor-pointer"
                                    @click="showPassword = !showPassword"
                                />
                            </template>
                        </q-input>
                    </q-card-section>

                    <q-separator inset />

                    <q-card-section>
                        <q-btn @click="handleLoginBtnClick" :loading="state.loading" class="full-width" color="indigo-8" label="Login" />
                    </q-card-section>
                </q-card>
            </q-page>
        </q-page-container>
    </q-layout>
</template>

<script lang="ts">
import { defineComponent, reactive, ref } from 'vue';
import { useAuthStore } from 'src/stores/auth.store';
import { useAuthService } from 'src/shared/core/services/auth.service';
import { LoginRequest } from 'src/shared/infrastructure/models/requests/auth/login-request.model';
import { useRouter } from 'vue-router';

export default defineComponent({
    setup() {
        const showPassword = ref<boolean>(false);

        const loginRequest = reactive<LoginRequest>({
            userName: '',
            password: ''
        });

        const authService = useAuthService();
        const { state } = useAuthStore();
        const router = useRouter();

        async function handleLoginBtnClick() {
            await authService.login(loginRequest);

            if (state.token)
                router.push({ path: '/app/publishers' })
        }

        return {
            state,
            loginRequest,
            showPassword,
            handleLoginBtnClick
        }
    }
})
</script>