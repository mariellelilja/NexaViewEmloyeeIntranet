<template>
    <div class="calendar-container mt-3">
        <div class="calendar-header">
            <h4>February 2024</h4>
        </div>
        <div class="calendar-grid">
            <div class="day-name" v-for="day in daysOfWeek" :key="day">{{ day }}</div>
            <!--Previous month, January-->
            <div class="day-number previous-month" v-for="n in 3" :key="'prev' + n"></div>
            <!--February-->
            <div class="day-number" v-for="n in totalDays" :key="n"
                :class="{ 'event-day': n === 28, 'todays-date': n === 22 }">{{ n }}</div>
        </div>
    </div>
</template>
  
<script>
export default {
    name: 'NVCalendar',
    data() {
        return {
            daysOfWeek: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
            totalDays: 29, //For now: February 29 days (mock)
        };
    },
};
</script>
  
<style scoped>
.calendar-container {
    max-width: 400px;
    margin: auto;
    border: 1px solid #ddd;
    border-radius: 8px;
    overflow: hidden;
}

.calendar-header {
    background-color: #f7f7f7;
    padding: 10px;
    text-align: center;
    border-bottom: 1px solid #ddd;
}

.calendar-grid {
    display: grid;
    grid-template-columns: repeat(7, 1fr);
    text-align: center;
}

.day-name {
    background-color: #eee;
    padding: 5px;
    border-bottom: 1px solid #ddd;
}

.day-number {
    padding: 10px;
    border-bottom: 1px solid #ddd;
    border-right: 1px solid #ddd;
}

.day-number:nth-child(7n) {
    border-right: none;
}

.previous-month {
    color: #999;
    /* Shade of gray to indicate it's not the current month */
}

.event-day {
    background-color: #4f0080c5;
    color: white;
}

.todays-date {
    background-color: #3b675ec9;
    /* TODO global, reoccuring colors */
    color: white;
}
</style>
  