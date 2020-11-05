function showPopup(content) {
  cover = document.createElement('div');
  cover.classList.add('mycover');
  document.body.appendChild(cover);

  div = document.createElement('div');
  div.innerHTML = content;
  div.classList.add('mymodal');
  document.body.appendChild(div);

  // CENTER THE DIALOG
  let left = (window.innerWidth - div.clientWidth) / 2;
  let top = (window.innerHeight - div.clientHeight) / 2;

  div.style.top = top + 'px';
  div.style.left = left + 'px';

  but = document.createElement('button');
  but.innerHTML = "CLOSE ME";
  but.onclick = function () {
    document.body.removeChild(div);
    document.body.removeChild(cover);
  }
  div.appendChild(but);

}