<template>
<html>
    <head>      
    </head>
    <headers />
   
    <!-- Modal Sing IN -->
    <body>
    <router-view />
    </body>
    <footers />
</html>
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

