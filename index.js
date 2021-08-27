createUnityInstance(document.querySelector("#unity-canvas"), {
  dataUrl: "Build/hackathon_test.data",
  frameworkUrl: "Build/hackathon_test.framework.js",
  codeUrl: "Build/hackathon_test.wasm",
  streamingAssetsUrl: "StreamingAssets",
  companyName: "DefaultCompany",
  productName: "Hackathon - Grp 1",
  productVersion: "1.0",
});
