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
                        <q-input v-model="loginModel.userName" outlined label="Username" class="q-mb-md">
                            <template v-slot:prepend>
                                <q-icon name="person" color="indigo-6" />
                            </template>
                            <template v-slot:append>
                                <q-icon name="event" color="indigo-6" />
                            </template>
                        </q-input>

                        <q-input v-model="loginModel.password" outlined :type="showPassword ? 'text' : 'password'">
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
                        <q-btn class="full-width" color="indigo-8" label="Login" />
                    </q-card-section>
                </q-card>
            </q-page>
        </q-page-container>
    </q-layout>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';

export default defineComponent({
    setup() {
        const showPassword = ref<boolean>(false);

        const loginModel = {
            userName: '',
            password: ''
        }

        return {
            loginModel,
            showPassword
        }
    }
})
</script>