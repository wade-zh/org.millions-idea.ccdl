@echo off
"..\..\bin-gpu-cuda8.0\caffe.exe" train --solver=solver.prototxt --snapshot=models/res_lstm_ctc_iter_35268.solverstate
pause