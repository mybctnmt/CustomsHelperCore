<!--需要复杂的请参考:https://preview.pro.loacg.com/dashboard/analysis-->
<template>
  <div class="page-header-index-wide">

  </div>
</template>
<script>
import ChartCard from '@/components/ChartCard/ChartCard'
import Trend from '@/components/ChartCard/Trend'

export default {
  components: {
    ChartCard,
    Trend
  },
  data () {
    return {
      loading: false
    }
  }
}
</script>