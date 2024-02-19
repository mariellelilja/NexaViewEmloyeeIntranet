<template>
    <div class="centered-message">
        <h1 class="friendly-text smooth-landing welcome-message">Welcome, {{ username }}!</h1>
        <p class="subheading m-4">What are you looking for today? </p>
    </div>
    <div class="dashboard-flex mt-5">

        <div class="main-section mt-5">
            <ArticlesGrid></ArticlesGrid>
        </div>

        <aside class="sidebar mt-5">
            <div class="calendar">
                <h3>Our Calendar</h3>
                <NVCalendar></NVCalendar>

                <!-- Calendar component, Umbraco?? -->
            </div>
            <div class="upcoming-events mt-5">
                <h4>Upcoming happenings</h4>
                <!---Mocked, will iterate over events, sorting them and displaying the 10 closest in time -->
                <ul class="m-3">
                    <li>
                        <span class="text-span event-date">28 February 2024</span>
                        <span class="text-span event-title">Grand Opening Celebration</span>

                    </li>
                    <li>
                        <span class="text-span event-date">14 March 2024</span>
                        <span class="text-span event-title">Social event: Escape room</span>
                    </li>
                    <li>
                        <span class="text-span event-date">2 April 2024</span>
                        <span class="text-span event-title">Seminar: Optimize the cloud (online)</span>
                    </li>
                </ul>
            </div>
        </aside>

    </div>


    <!--Grids or buttons with alternatives?-->
    <!---Company articles-->
</template>
  
<script>
import apiService from '@/services/apiService';
import ArticlesGrid from './ArticlesGrid.vue';
import NVCalendar from './NVCalendar.vue';

export default {
    components: { ArticlesGrid, NVCalendar },
    name: 'LandingDashboard',
    data() {
        return {
            username: 'Lise Mockname',
        };
    },
    methods: { /* TODO move auth logic? */
        async fetchEmployeeName() {
            try {
                const response = await apiService.get('/api2/user/GetCurrentUserName');
                this.username = response.data;
            } catch (error) {
                console.error('There was an error fetching the employee name:', error);
            }
        },
    }
}
</script>
  
<style scoped>
.centered-message {
    display: block;
    text-align: center;
}

.welcome-message {
    font-size: 48px;
}

.subheading {
    font-size: 30px;
}

.dashboard-flex {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}

.main-section {
    flex: 3;
}

.calendar h3,
h4 {
    padding-left: 1rem;
}

.sidebar {
    flex: 1;
    /* Adjusts the sidebar width to 1/4 of the container */
    padding-left: 4rem;
}

@media (max-width: 768px) {
    .dashboard-flex {
        flex-direction: column;
    }

    .main-section,
    .sidebar {
        flex: none;
    }
}

.upcoming-events ul {
    list-style: none;
    padding: 0;
    text-align: left;
    padding-left: 0rem;
}

.upcoming-events li {
    margin-bottom: 10px;
}

.event-date {
    font-weight: bold;
    color: #360654c5;
    /* Not looking pretty, but for now */
}

.event-title {
    margin-left: 10px;
}
</style>