<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// Sometimes you need to access a LINQPad control from within JavaScript.
// To do this, LINQPad provides Eval and Run methods on HtmlElement.
// These set up a variable called 'targetElement' which refers to the control.

var label = new Label ("Test").Dump();
label.HtmlElement.Run ("targetElement.innerText = 'Set via JavaScript!'");

// NOTE: HtmlElement.Run does more than just set up the 'targetElement' variable.
// It also prevents races by delaying execution until the control is available in the DOM.
// This is important because to maximize performance, Dump does *not* execute synchronously.

// Here's a more elaborate example, illustrating the use of Three.js (a JavaScript 3D library):

var container = new Div()
	.WithStyle ("width", "400px")
	.WithStyle ("height", "400px");

container.Dump ("Three.js - 3D Torus Knot");

container.HtmlElement.Run ("""
	import('https://cdn.jsdelivr.net/npm/three@0.170.0/build/three.module.js').then(THREE => {
		const el = targetElement;
		const scene = new THREE.Scene();
		const camera = new THREE.PerspectiveCamera(75, el.clientWidth / el.clientHeight, 0.1, 1000);
		const renderer = new THREE.WebGLRenderer({ antialias: true });
		renderer.setSize(el.clientWidth, el.clientHeight);
		el.appendChild(renderer.domElement);

		const geometry = new THREE.TorusKnotGeometry(1, 0.3, 128, 32);
		const material = new THREE.MeshNormalMaterial();
		const mesh = new THREE.Mesh(geometry, material);
		scene.add(mesh);
		camera.position.z = 4;

		function animate() {
			requestAnimationFrame(animate);
			mesh.rotation.x += 0.01;
			mesh.rotation.y += 0.015;
			renderer.render(scene, camera);
		}
		animate();
	});
""");

// NOTE: Remember that JavaScript executes in the global script scope.
// If you need to exit early using a 'return' statement, wrap your code in an IIFE.