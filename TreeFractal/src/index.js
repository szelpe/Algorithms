let canvas = document.getElementById("canvas");
let ctx = canvas.getContext("2d");

let canvasHeight = 500;

let base1 = [250, 500];
let base2 = [250, 430];

ctx.beginPath();
ctx.lineWidth = 9;
ctx.moveTo(base1[0], base1[1]);
ctx.lineTo(base2[0], base2[1]);
ctx.stroke();

let v0 = [base2[0] - base1[0], base2[1] - base1[1]];

drawV(base2[0], base2[1], v0, 0);

async function drawV(startX, startY, directionVector, level) {
  if (level > 8) return;
  ctx.lineWidth = 8 - level;
  await delay(1000 / 30);
  let v1 = rotate(directionVector, toRad(20));
  let v2 = rotate(directionVector, toRad(-20));

  drawLine([startX, startY], v1);
  let end1 = [startX + v1[0], startY + v1[1]];
  drawV(end1[0], end1[1], multiply(v1, 0.8), level + 1);

  drawLine([startX, startY], v2);
  let end2 = [startX + v2[0], startY + v2[1]];
  drawV(end2[0], end2[1], multiply(v2, 0.8), level + 1);
}

function multiply(v, amount) {
  return [v[0] * amount, v[1] * amount];
}

function delay(ms) {
  return new Promise((res) => setTimeout(res, ms));
}

function rotate(p, fi) {
  let [x, y] = p;
  return [
    x * Math.cos(fi) - y * Math.sin(fi),
    x * Math.sin(fi) + y * Math.cos(fi)
  ];
}

function drawLine(startPoint, vector) {
  ctx.beginPath();
  ctx.moveTo(startPoint[0], startPoint[1]);
  ctx.lineTo(startPoint[0] + vector[0], startPoint[1] + vector[1]);
  ctx.stroke();
}

function toRad(degrees) {
  var pi = Math.PI;
  return degrees * (pi / 180);
}
