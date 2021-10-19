<template>
<div>
    <headers />
   
    <!-- Modal Sing IN -->

    <router-view />

    <footers />
</div>
</template>


<script>
import footers from '@/components/app/footer'
import headers from '@/components/app/header'

export default{
    components:{
        footers,headers
    }
}
</script>

