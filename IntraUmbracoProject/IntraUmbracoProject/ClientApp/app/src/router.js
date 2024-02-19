import { createRouter, createWebHistory } from 'vue-router';

import LoginForm from './components/LoginForm.vue';
import RegisterForm from './components/RegisterForm.vue';
import LandingDashboard from './components/LandingDashboard.vue';

const routes = [ //TODO Add names?
    { path: '/', component: LandingDashboard },
    { path: '/dashboard', component: LandingDashboard },
    { path: '/login', component: LoginForm },
    { path: '/register', component: RegisterForm },
    // { path: '/nvarticles', component: ArticlesComponent },
    // { path: '/nvpeople', component: EmployeeBase },
    // { path: '/nvdocs', component: DocumentBase },
    // { path: '/nvresources', component: CompanyResources },
    // { path: '/nvsocial', component: CompanyEvents },
    // { path: '/nvcoe', component: KnowledegBase },
    // {
    //     path: '/myprofile', component: TODO,
    //     children: [
    //         {
    //             path: 'settings',
    //             component: ProfileSettings,

    //         },
    //         {
    //             path: 'mydocs',
    //             component: ProfileDocuments,

    //         },
    //         {
    //             path: 'savedcontacts',
    //             component: Contancts,

    //         },
    //     ]
    // },
];

const router = createRouter({
    history: createWebHistory(),
    routes, // = 'routes: routes'
});

export default router;