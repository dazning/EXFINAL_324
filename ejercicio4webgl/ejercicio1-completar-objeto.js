var camera, scene, renderer;
var cameraControls;
var clock = new THREE.Clock();
var ambientLight, light;

function init() {
    var canvasWidth = window.innerWidth * 0.9;
    var canvasHeight = window.innerHeight * 0.9;

    // CAMERA
    camera = new THREE.PerspectiveCamera(45, window.innerWidth / window.innerHeight, 1, 80000);
    camera.position.set(0, 1, 5);
    camera.lookAt(0, 1, 0);

    // LIGHTS
    light = new THREE.DirectionalLight(0xFFFFFF, 0.7);
    light.position.set(1, 1, 1);
    light.target.position.set(0, 0, 0);
    light.target.updateMatrixWorld();

    var ambientLight = new THREE.AmbientLight(0x111111);

    // RENDERER
    renderer = new THREE.WebGLRenderer({ antialias: true });
    renderer.setSize(canvasWidth, canvasHeight);
    renderer.setClearColor(0xAAAAAA, 1.0);

    // Add to DOM
    var container = document.getElementById('container');
    container.appendChild(renderer.domElement);

    // CONTROLS
    cameraControls = new THREE.OrbitControls(camera, renderer.domElement);
    cameraControls.target.set(0, 1, 0);

    // OBJECTS
    // Pirámide
    var treeGeometry = new THREE.Geometry();
    treeGeometry.vertices.push(new THREE.Vector3(0, 1, 0));
    treeGeometry.vertices.push(new THREE.Vector3(-0.5, 0, -0.5));
    treeGeometry.vertices.push(new THREE.Vector3(0.5, 0, -0.5));
    treeGeometry.vertices.push(new THREE.Vector3(0.5, 0, 0.5));
    treeGeometry.vertices.push(new THREE.Vector3(-0.5, 0, 0.5));
    treeGeometry.faces.push(new THREE.Face3(0, 1, 2));
    treeGeometry.faces.push(new THREE.Face3(0, 2, 3));
    treeGeometry.faces.push(new THREE.Face3(0, 3, 4));
    treeGeometry.faces.push(new THREE.Face3(0, 4, 1));
    var treeMaterial = new THREE.MeshBasicMaterial({ color: 0x008000, side: THREE.DoubleSide });
    var treeObject = new THREE.Mesh(treeGeometry, treeMaterial);

    // Tronco
    var trunkGeometry = new THREE.BoxGeometry(0.2, 1.5, 0.2);
    var trunkMaterial = new THREE.MeshBasicMaterial({ color: 0x5C2B10 });
    var trunkObject = new THREE.Mesh(trunkGeometry, trunkMaterial);
    trunkObject.position.set(0, 0.25, 0); // Ajusta la posición del tronco

    // Escena
    scene = new THREE.Scene();
    scene.add(light);
    scene.add(ambientLight);
    scene.add(treeObject);
    scene.add(trunkObject);

    // Crear y añadir copias adicionales del árbol justo encima del original
    var treeObject2 = treeObject.clone();
    treeObject2.position.set(0, 0.5, 0);
    scene.add(treeObject2);

    var treeObject3 = treeObject.clone();
    treeObject3.position.set(0, 1, 0);
    scene.add(treeObject3);
}

function animate() {
    window.requestAnimationFrame(animate);
    render();
}

function render() {
    var delta = clock.getDelta();
    cameraControls.update(delta);
    renderer.render(scene, camera);
}

try {
    init();
    animate();
} catch (e) {
    var errorReport = "Your program encountered an unrecoverable error, can not draw on canvas. Error was:<br/><br/>";
    $('#container').append(errorReport + e);
}
