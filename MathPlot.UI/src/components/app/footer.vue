<template>
     <mdb-footer class="bg-light text-center text-lg-start">
        <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
              &copy; 2021 MathPlot
        </div>
     </mdb-footer>
</template>

<script>
  import { mdbFooter} from 'mdbvue';
  export default {
    name: 'FooterPage',
    components: {
      mdbFooter
    }
  }
</script>