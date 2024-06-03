const formatTime = date => {
  const year = date.getFullYear()
  const month = date.getMonth() + 1
  const day = date.getDate()
  const hour = date.getHours()
  const minute = date.getMinutes()
  const second = date.getSeconds()

  return `${[year, month, day].map(formatNumber).join('-')} ${[hour, minute, second].map(formatNumber).join(':')}`
}

const formatNumber = n => {
  n = n.toString()
  return n[1] ? n : `0${n}`
}

function getFileName (name) {
  return name.substring(0, name.lastIndexOf("."))
}

// // 获取 .后缀名
// function getExtension (name) {
//   return name.substring(name.lastIndexOf("."))
// }

// 只获取后缀名
function getExtension (name) {
  return name.substring(name.lastIndexOf(".")+1)
}

function getGuid() {
  var guid = ""
  for(var i=1;i<=32;i++){
      var n = Math.floor(Math.random()*16.0).toString(16);
      guid += n;
      if((i==8)||(i==12)||(i==16)||(i==20))
          guid += "-";
  }
  return guid;
}

module.exports = {
  formatTime,
  getFileName,
  getExtension,
  getGuid
}
