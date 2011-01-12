<?php
$FILENAME="image_name";
// 生成图片的宽度
$RESIZEWIDTH=400;
// 生成图片的高度
$RESIZEHEIGHT=400;

Function ResizeImage($im, $maxwidth, $maxheight, $name) {
    $width = ImagesX($im);
    $height = ImagesY($im);
    If (($maxwidth && $width > $maxwidth) || ($maxheight && $height > $maxheight)) {
        If ($maxwidth && $width > $maxwidth) {
            $widthratio = $maxwidth/$width;
            $RESIZEWIDTH = True;
        }
        
        If ($maxheight && $height > $maxheight) {
            $heightratio = $maxheight/$height;
            $RESIZEHEIGHT = True;
        }
        
        If ($RESIZEWIDTH && $RESIZEHEIGHT) {
            If ($widthratio < $heightratio) {
                $ratio = $widthratio;
            } Else {
                $ratio = $heightratio;
            }
        } ElseIf ($RESIZEWIDTH) {
            $ratio = $widthratio;
        } ElseIf ($RESIZEHEIGHT) {
            $ratio = $heightratio;
        }
        
        $newwidth = $width * $ratio;
        $newheight = $height * $ratio;
        If (Function_Exists("imagecopyresampled")) {
            $newim = ImageCreateTrueColor($newwidth, $newheight);
            ImageCopyResampled($newim, $im, 0, 0, 0, 0, $newwidth, $newheight, $width, $height);
        } Else {
            $newim = ImageCreate($newwidth, $newheight);
            ImageCopyResized($newim, $im, 0, 0, 0, 0, $newwidth, $newheight, $width, $height);
        }
        ImageJpeg ($newim,$name . ".jpg");
        ImageDestroy ($newim);
    } Else {
        ImageJpeg ($im,$name . ".jpg");
    }
}

If ($_FILES['image']['size']) {
    If ($_FILES['image']['type'] == "image/pjpeg") {
        $im = ImageCreateFromJpeg($_FILES['image']['tmp_name']);
    } ElseIf ($_FILES['image']['type'] == "image/x-png") {
    $im = ImageCreateFromPng($_FILES['image']['tmp_name']);
    } ElseIf ($_FILES['image']['type'] == "image/gif") {
        $im = ImageCreateFromGif($_FILES['image']['tmp_name']);
    }
    
    If ($im){
        If (File_Exists("$FILENAME.jpg")) {
            UnLink("$FILENAME.jpg");
        }
        ResizeImage($im, $RESIZEWIDTH, $RESIZEHEIGHT, $FILENAME);
        ImageDestroy($im);
    }
}
?>
<html>
<body>
    <img src="<? echo($FILENAME.".jpg?reload=".rand(0,999999)); ?>"><br /><br />
    <form enctype="multipart/form-data" method="post">
      <br />
      <input type="file" name="image" size="50" value="浏览">
      <p/>
      <input type="submit" value="上传图片">
    </form>
</body>
</html>