import { getDataList } from "@services/api/ttaskhead";
Component({
  /**
   * 组件的属性列表
   */
  properties: {
    type: {
      type: Number,
      value: 1
    },
  },

  /**
   * 组件的初始数据
   */
  data: {
    taskheads: [],
    pageIndex: 1,
    pageRows: 10,
    isLoading: true,
    image: "/assets/images/empty.png",
    triggered: true
  },

  /**
   * 组件的方法列表
   */
  methods: {
    async getDataList() {
      this.setData({ isLoading: true });
      const { pageIndex, pageRows, taskheads, type } = this.data;
      try {
        let dataList = await getDataList({
          "PageIndex": pageIndex,
          "PageRows": pageRows,
          "Type": type
        });
        if (dataList.Success) {
          if (pageIndex === 1) {
            this.setData({
              taskheads: [...dataList.Data],
              isLoading: false
            });
          } else {
            this.setData({
              taskheads: [...taskheads, ...dataList.Data],
              isLoading: false
            });
          }
        } else {
          this.setData({ isLoading: false });
          wx.showToast({
            title: dataList.Msg,
            icon: "none"
          });
        }
      } catch (error) {
        this.setData({ isLoading: false });
        wx.showToast({
          title: error.errMsg,
          icon: "none"
        });
      }
    },
    
    handleTap(e) {
      const id = e.currentTarget.dataset.id;
      const { type, taskheads } = this.data;
      wx.navigateTo({
        url: '/pages/common/task-detail/index?id=' + id,
        success: (res) => {
          res.eventChannel.on('unload', (taskInfo) => {
            switch(type) {
              case 1:
                if (taskInfo.ttaskhead.ReceiverId) {
                  this.setData({
                    taskheads: taskheads.filter(item => item.Id !== taskInfo.ttaskhead.Id)
                  });
                }
                break;
              case 2:
                if (taskInfo.ttaskhead.IsCompleted) {
                  let updatedTaskheads = taskheads.map(item => {
                    if(item.Id === taskInfo.ttaskhead.Id) {
                      return {
                        ...item,
                        IsCompleted: taskInfo.ttaskhead.IsCompleted
                      };
                    } else {
                      return item;
                    }
                  });
                  this.setData({
                    taskheads: updatedTaskheads
                  });
                }
                break;
            }
          });
        }
      })
    },
  
    async onRefresh() {
      this.setData({
        pageIndex: 1,
        pageRows: 10
      })
      await this.getDataList();
      this.setData({ triggered: false });
    },
  
    async scrollToLower() {
      const { pageIndex } = this.data;
      this.setData({ pageIndex: pageIndex + 1 });
      await this.getDataList();
    }
  },

  lifetimes: {
    attached: async function() {
      await this.getDataList();
    },
    detached: function() {
      
    },
  },
})
