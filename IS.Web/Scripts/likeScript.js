var like = function(){
var isLiked = false;
var numcount = 0;

isLiked = (!isLiked);

    if (isLiked) {
        numcount += 1;
    } else numcount -= 1;

document.getElementById('likeCount').innerHTML = numcount;
}