<script type="text/javascript">
const colorList = [
  '#F9F900',
  '#6FB7B7',
  '#9999CC',
  '#B766AD',
  '#B87070',
  '#FF8F59',
  '#FFAF60',
  '#FFDC35',
  '#FFFF37',
  '#B7FF4A',
  '#28FF28',
  '#1AFD9C',
  '#00FFFF',
  '#2894FF',
  '#6A6AFF',
  '#BE77FF',
  '#FF77FF',
  '#FF79BC',
  '#FF2D2D',
  '#ADADAD'
];
const colorListLength = 20;
const isDev=true;
const requestDevServerPath="http://bill.bjwcom.cn:8002/api";
const requestReleaseServerPath="http://bill.bjwcom.cn:8001/api";
const requestServerPath=isDev?requestDevServerPath:requestReleaseServerPath;
const btnArray = ['否', '是'];
function getRandColor () {
  var tem = Math.round(Math.random() * colorListLength)
  return colorList[tem]
}
 
export default
{
  colorList,
  colorListLength,
  getRandColor,
  requestServerPath, 
  btnArray
}
</script>

作者：程序仲小仲
链接：https://www.jianshu.com/p/7547ff8760c3
來源：简书
简书著作权归作者所有，任何形式的转载都请联系作者获得授权并注明出处。