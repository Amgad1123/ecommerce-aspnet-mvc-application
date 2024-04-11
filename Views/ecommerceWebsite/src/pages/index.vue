<template>
  <v-app>
    <NavBar />
    <v-main>
      <v-container>

        <v-row>
          <v-col cols="12" sm="12">
            <v-carousel>
              <v-carousel-item v-for="(item, i) in items" :key="i" :src="item.src" cover>
                <v-row>
                  <v-col cols="12" sm="6">
                    <div class="d-flex fill-height justify-center align-center">
                      <h2 class="text-white top">{{ item.title }}</h2><br />
                    </div>
                    <div class="d-flex fill-height justify-center align-center">
                      <p class="middle text-white">{{ item.text }}</p>
                    </div>
                    <div class="d-flex fill-height justify-center align-center">
                      <v-btn style="margin-top: -120px;">Purchase</v-btn>
                    </div>
                  </v-col>
                </v-row>
              </v-carousel-item>
            </v-carousel> 
          </v-col>
        </v-row>
      </v-container>
    </v-main>
    <AppFooter />
  </v-app>
</template>

<script setup>
  import NavBar from '@/components/NavBar.vue';
  import AppFooter from '@/components/AppFooter.vue';
</script>

<script>
export default {
  data() {
    return {
      items: [
        {
          src: "@/assets/IMG_1.jpg",
          title: "Vitamin D Supplements",
          text: "For computer science majors who do not go outside.",
        },
        {
          src: "@/assets/IMG_1.jpg",
          title: "Omega-3 Supplements",
          text: "For computer science majors who sometimes go outside.",
        },
        {
          src: "@/assets/IMG_1.jpg",
          title: "Kid's Multi Vitamin Supplements",
          text: "For computer science kids who do not go outside.",
        },
      ],
    };
  },
};
</script>

<style scoped>
.top {
  margin-top: 100px;
}

.text {
  margin-top: -40px;
  margin-left: 80px;
}

.top-day {
  margin-top: 120px;
}
</style>
