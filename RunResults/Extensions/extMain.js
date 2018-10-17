(function () {
	var nodeTypes = {
		suite: 'Suite',
		testContainer: 'TestContainer'
	};
	var isNodeTypeSupport = function (nodeType) {
		for (var p in nodeTypes) {
			if (nodeTypes[p] === nodeType)
				return true;
		}
	};

	var getNodeType =  function (context) {
		return __reportExtension.utils.fromDetailData.getReportNodeType(context.detailData);
	};

	var isSupportedVerificationTO = function (context){
		if (context && context.detailData && context.detailData.type === "Step"){
			var operationDetails = context.detailData.test_obj_info;

			var overviewData = context.detailData.overview;

			if (overviewData.caption.indexOf("Run Error") > -1 && context.detailData.raw_data.Data.ErrorText){
				return false;
			}

			if (typeof(operationDetails.operation) === 'string'){
				var operation = operationDetails.operation.toLowerCase();
				if (operation === "verifyimageexists" || operation === "verifyimagematch" ){
					return true;
				}
			}
		}
		return false;
	};

	__reportExtension.addExternalRender('RKey:TestFlowTree.Node.Visibility', {
		// preCheck callback
		preCheck: function (context, args) {
			var nodeType = __reportExtension.utils.fromDetailData.getReportNodeType(context.detailData);
			if (isNodeTypeSupport(nodeType))
				args.needExec = true;

			if (context && context.nodeDataModel && context.nodeDataModel.caption && context.nodeDataModel.caption.objects_chain){
				context.nodeDataModel.caption.objects_chain.map(function(item){
					if (item.icon_key === "bgicon-default-test-obj"){
						item.icon_key = "c-icon-" + item.object_type.split(".")[1];
					}
				})
			}

			// change verifyImageExists icon
			if (isSupportedVerificationTO(context)){
				if (context.detailData.status === "error")
					context.nodeDataModel.status_indicator_iconkey = "VerifyFailure"
				else
					context.nodeDataModel.status_indicator_iconkey = "VerifySuccess"
			}
		},

		// execute callback
		execute: function (context, args) {
			context.show_node = true;
		}
	});

	__reportExtension.addExternalRender('RKey:DetailsPane.Caption', {
		preCheck: function (context, args) {
			if (isNodeTypeSupport(getNodeType(context)))
				args.needExec = true;

			// the context contains TO with verification
			if (isSupportedVerificationTO(context))
				args.needExec = true;
		},

		// execute callback
		execute: function (context, args) {
			var caption = "";
			var nodeType = getNodeType(context);
			var isError = context.detailData.status;
			if (isNodeTypeSupport(nodeType)){
				var detailsCaption = isError.toLowerCase() === 'error' ? 'Error': nodeType.split(/(?=[A-Z])/).join(" ");
				caption = '<span class=my-ext-details-caption>' + detailsCaption + ' Details</span>';
			}
			else{
				var detailsCaption =isError.toLowerCase() === 'error' ? 'Error' : 'Verification';
				caption = '<span class=my-ext-details-caption>' + detailsCaption + 'Details</span>';
			}
			new DetailsPaneCaptionRenderer(caption).render(context.parent);
		}
	});

	__reportExtension.addExternalRender('RKey:DetailsPane.Section.Overview.Caption', {
		preCheck: function (context, args) {
			if (isNodeTypeSupport(getNodeType(context)))
				args.needExec = true;

			// the context contains TO with verification
			if (isSupportedVerificationTO(context))
				args.needExec = true;
		},

		// execute callback
		execute: function (context, args) {
			var caption = "";
			var nodeType = getNodeType(context);
			var errorText = context.detailData.status.toLowerCase() == 'error' ? "Run Error - " : "";
			if (isNodeTypeSupport(nodeType)) {
				caption = '<span class="cust-caption-detail">'+ errorText + nodeType.split(/(?=[A-Z])/).join(" ") + '</span>';
			}
			else{
				caption = '<span class="cust-caption-detail"> + errorText + Verification</span>';
			}
			new DetailsOverviewSectionCaptionRenderer(caption).render(context.parent);
		}
	});


	__reportExtension.addExternalRender('RKey:TestFlowTree.Node.Caption.Icon', {
		// preCheck callback
		preCheck: function (context, args) {
			var nodeType = __reportExtension.utils.fromReportNode.getReportNodeType(context.reportNode);
			if (nodeType === nodeTypes.suite || nodeType === nodeTypes.testContainer)
				args.needExec = true;
		},

		// execute callback
		execute: function (context, args) {
			var nodeType = __reportExtension.utils.fromReportNode.getReportNodeType(context.reportNode);
			switch(nodeType) {
				case nodeTypes.suite:
					context.icon_key = 'my-node-suite-icon';
					context.icon_tooltip = context.icon_tooltip;
					break;
				case nodeTypes.testContainer:
					context.icon_key = 'my-node-test-container-icon';
					context.icon_tooltip = 'Test Container(\"' + context.reportNode.Data.Name + '\")';
					break;
			}
		}
	});
})();


// SIG // Begin signature block
// SIG // MIIjpAYJKoZIhvcNAQcCoIIjlTCCI5ECAQExDzANBglg
// SIG // hkgBZQMEAgEFADB3BgorBgEEAYI3AgEEoGkwZzAyBgor
// SIG // BgEEAYI3AgEeMCQCAQEEEBDgyQbOONQRoqMAEEvTUJAC
// SIG // AQACAQACAQACAQACAQAwMTANBglghkgBZQMEAgEFAAQg
// SIG // AKQBcy5btFhE+DDWWQ5S6EX0UKaS4yrk7sKShAus9Lmg
// SIG // gh6yMIID7jCCA1egAwIBAgIQfpPr+3zGTlnqS5p31Ab8
// SIG // OzANBgkqhkiG9w0BAQUFADCBizELMAkGA1UEBhMCWkEx
// SIG // FTATBgNVBAgTDFdlc3Rlcm4gQ2FwZTEUMBIGA1UEBxML
// SIG // RHVyYmFudmlsbGUxDzANBgNVBAoTBlRoYXd0ZTEdMBsG
// SIG // A1UECxMUVGhhd3RlIENlcnRpZmljYXRpb24xHzAdBgNV
// SIG // BAMTFlRoYXd0ZSBUaW1lc3RhbXBpbmcgQ0EwHhcNMTIx
// SIG // MjIxMDAwMDAwWhcNMjAxMjMwMjM1OTU5WjBeMQswCQYD
// SIG // VQQGEwJVUzEdMBsGA1UEChMUU3ltYW50ZWMgQ29ycG9y
// SIG // YXRpb24xMDAuBgNVBAMTJ1N5bWFudGVjIFRpbWUgU3Rh
// SIG // bXBpbmcgU2VydmljZXMgQ0EgLSBHMjCCASIwDQYJKoZI
// SIG // hvcNAQEBBQADggEPADCCAQoCggEBALGss0lUS5ccEgrY
// SIG // JXmRIlcqb9y4JsRDc2vCvy5QWvsUwnaOQwElQ7Sh4kX0
// SIG // 6Ld7w3TMIte0lAAC903tv7S3RCRrzV9FO9FEzkMScxeC
// SIG // i2m0K8uZHqxyGyZNcR+xMd37UWECU6aq9UksBXhFpS+J
// SIG // zueZ5/6M4lc/PcaS3Er4ezPkeQr78HWIQZz/xQNRmarX
// SIG // bJ+TaYdlKYOFwmAUxMjJOxTawIHwHw103pIiq8r3+3R8
// SIG // J+b3Sht/p8OeLa6K6qbmqicWfWH3mHERvOJQoUvlXfrl
// SIG // Dqcsn6plINPYlujIfKVOSET/GeJEB5IL12iEgF1qeGRF
// SIG // zWBGflTBE3zFefHJwXECAwEAAaOB+jCB9zAdBgNVHQ4E
// SIG // FgQUX5r1blzMzHSa1N197z/b7EyALt0wMgYIKwYBBQUH
// SIG // AQEEJjAkMCIGCCsGAQUFBzABhhZodHRwOi8vb2NzcC50
// SIG // aGF3dGUuY29tMBIGA1UdEwEB/wQIMAYBAf8CAQAwPwYD
// SIG // VR0fBDgwNjA0oDKgMIYuaHR0cDovL2NybC50aGF3dGUu
// SIG // Y29tL1RoYXd0ZVRpbWVzdGFtcGluZ0NBLmNybDATBgNV
// SIG // HSUEDDAKBggrBgEFBQcDCDAOBgNVHQ8BAf8EBAMCAQYw
// SIG // KAYDVR0RBCEwH6QdMBsxGTAXBgNVBAMTEFRpbWVTdGFt
// SIG // cC0yMDQ4LTEwDQYJKoZIhvcNAQEFBQADgYEAAwmbj3nv
// SIG // f1kwqu9otfrjCR27T4IGXTdfplKfFo3qHJIJRG71betY
// SIG // fDDo+WmNI3MLEm9Hqa45EfgqsZuwGsOO61mWAK3ODE2y
// SIG // 0DGmCFwqevzieh1XTKhlGOl5QGIllm7HxzdqgyEIjkHq
// SIG // 3dlXPx13SYcqFgZepjhqIhKjURmDfrYwggSjMIIDi6AD
// SIG // AgECAhAOz/Q4yP6/NW4E2GqYGxpQMA0GCSqGSIb3DQEB
// SIG // BQUAMF4xCzAJBgNVBAYTAlVTMR0wGwYDVQQKExRTeW1h
// SIG // bnRlYyBDb3Jwb3JhdGlvbjEwMC4GA1UEAxMnU3ltYW50
// SIG // ZWMgVGltZSBTdGFtcGluZyBTZXJ2aWNlcyBDQSAtIEcy
// SIG // MB4XDTEyMTAxODAwMDAwMFoXDTIwMTIyOTIzNTk1OVow
// SIG // YjELMAkGA1UEBhMCVVMxHTAbBgNVBAoTFFN5bWFudGVj
// SIG // IENvcnBvcmF0aW9uMTQwMgYDVQQDEytTeW1hbnRlYyBU
// SIG // aW1lIFN0YW1waW5nIFNlcnZpY2VzIFNpZ25lciAtIEc0
// SIG // MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA
// SIG // omMLOUS4uyOnREm7Dv+h8GEKU5OwmNutLA9KxW7/hjxT
// SIG // VQ8VzgQ/K/2plpbZvmF5C1vJTIZ25eBDSyKV7sIrQ8Gf
// SIG // 2Gi0jkBP7oU4uRHFI/JkWPAVMm9OV6GuiKQC1yoezUvh
// SIG // 3WPVF4kyW7BemVqonShQDhfultthO0VRHc8SVguSR/yr
// SIG // rvZmPUescHLnkudfzRC5xINklBm9JYDh6NIipdC6Anqh
// SIG // d5NbZcPuF3S8QYYq3AhMjJKMkS2ed0QfaNaodHfbDlsy
// SIG // i1aLM73ZY8hJnTrFxeozC9Lxoxv0i77Zs1eLO94Ep3oi
// SIG // siSuLsdwxb5OgyYI+wu9qU+ZCOEQKHKqzQIDAQABo4IB
// SIG // VzCCAVMwDAYDVR0TAQH/BAIwADAWBgNVHSUBAf8EDDAK
// SIG // BggrBgEFBQcDCDAOBgNVHQ8BAf8EBAMCB4AwcwYIKwYB
// SIG // BQUHAQEEZzBlMCoGCCsGAQUFBzABhh5odHRwOi8vdHMt
// SIG // b2NzcC53cy5zeW1hbnRlYy5jb20wNwYIKwYBBQUHMAKG
// SIG // K2h0dHA6Ly90cy1haWEud3Muc3ltYW50ZWMuY29tL3Rz
// SIG // cy1jYS1nMi5jZXIwPAYDVR0fBDUwMzAxoC+gLYYraHR0
// SIG // cDovL3RzLWNybC53cy5zeW1hbnRlYy5jb20vdHNzLWNh
// SIG // LWcyLmNybDAoBgNVHREEITAfpB0wGzEZMBcGA1UEAxMQ
// SIG // VGltZVN0YW1wLTIwNDgtMjAdBgNVHQ4EFgQURsZpow5K
// SIG // FB7VTNpSYxc/Xja8DeYwHwYDVR0jBBgwFoAUX5r1blzM
// SIG // zHSa1N197z/b7EyALt0wDQYJKoZIhvcNAQEFBQADggEB
// SIG // AHg7tJEqAEzwj2IwN3ijhCcHbxiy3iXcoNSUA6qGTiWf
// SIG // mkADHN3O43nLIWgG2rYytG2/9CwmYzPkSWRtDebDZw73
// SIG // BaQ1bHyJFsbpst+y6d0gxnEPzZV03LZc3r03H0N45ni1
// SIG // zSgEIKOq8UvEiCmRDoDREfzdXHZuT14ORUZBbg2w6jia
// SIG // sTraCXEQ/Bx5tIB7rGn0/Zy2DBYr8X9bCT2bW+IWyhOB
// SIG // bQAuOA2oKY8s4bL0WqkBrxWcLC9JG9siu8P+eJRRw4ax
// SIG // gohd8D20UaF5Mysue7ncIAkTcetqGVvP6KUwVyyJST+5
// SIG // z3/Jvz4iaGNTmr1pdKzFHTx/kuDDvBzYBHUwggVMMIID
// SIG // NKADAgECAhMzAAAANdjVWVsGcUErAAAAAAA1MA0GCSqG
// SIG // SIb3DQEBBQUAMH8xCzAJBgNVBAYTAlVTMRMwEQYDVQQI
// SIG // EwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4w
// SIG // HAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xKTAn
// SIG // BgNVBAMTIE1pY3Jvc29mdCBDb2RlIFZlcmlmaWNhdGlv
// SIG // biBSb290MB4XDTEzMDgxNTIwMjYzMFoXDTIzMDgxNTIw
// SIG // MzYzMFowbzELMAkGA1UEBhMCU0UxFDASBgNVBAoTC0Fk
// SIG // ZFRydXN0IEFCMSYwJAYDVQQLEx1BZGRUcnVzdCBFeHRl
// SIG // cm5hbCBUVFAgTmV0d29yazEiMCAGA1UEAxMZQWRkVHJ1
// SIG // c3QgRXh0ZXJuYWwgQ0EgUm9vdDCCASIwDQYJKoZIhvcN
// SIG // AQEBBQADggEPADCCAQoCggEBALf3GjPm8gAELTngTlvt
// SIG // H7xsD821+iO2zt6bETOXpClMfZOfvUq8k+0DGuOPz+Vt
// SIG // UFrWlymUWoCwSXrbLpX9uMq/NzgtHj6RQa1wVsfwTz/o
// SIG // Mp50ysiQVOnGXw94nZpAPA6sYapeFI+eh6FqUNzXmk6v
// SIG // BbOmcZSccbNQYArHE504B4YCqOmoaSYYkKtMsE8jqzpP
// SIG // hNjfzp/haW+710LXa0Tkx63ubUFfclpxCDezeWWkWaCU
// SIG // N/cALw3CknLa0Dhy2xSoRcRdKn23tNbE7qzNE0S3ySvd
// SIG // QwAl+mG5aWpYIxG3pzOPVnVZ9c0p10a3CitlttNCbxWy
// SIG // uHv77+ldU9U0WicCAwEAAaOB0DCBzTATBgNVHSUEDDAK
// SIG // BggrBgEFBQcDAzASBgNVHRMBAf8ECDAGAQH/AgECMB0G
// SIG // A1UdDgQWBBStvZh6NLQm9/rEJlTvA73gJMtUGjALBgNV
// SIG // HQ8EBAMCAYYwHwYDVR0jBBgwFoAUYvsKIVt/Q24R2glU
// SIG // UGv10pZx8Z4wVQYDVR0fBE4wTDBKoEigRoZEaHR0cDov
// SIG // L2NybC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVj
// SIG // dHMvTWljcm9zb2Z0Q29kZVZlcmlmUm9vdC5jcmwwDQYJ
// SIG // KoZIhvcNAQEFBQADggIBADYrovLhMx/kk/fyaYXGZA7J
// SIG // m2Mv5HA3mP2U7HvP+KFCRvntak6NNGk2BVV6HrutjJlC
// SIG // lgbpJagmhL7BvxapfKpbBLf90cD0Ar4o7fV3x5v+Ovbo
// SIG // wXvTgqv6FE7PK8/l1bVIQLGjj4OLrSslU6umNM7yQ/dP
// SIG // LOndHk5atrroOxCZJAC8UP149uUjqImUk/e3QTA3Sle3
// SIG // 5kTZyd+ZBapE/HSvgmTMB8sBtgnDLuPoMqe0n0F4x6GE
// SIG // NlRi8uwVCsjq0IT48eBr9FYSX5Xg/N23dpP+KUol6QQA
// SIG // 8bQRDsmEntsXffUepY42KRk6bWxGS9ercCQojQWj2dUk
// SIG // 8vig0TyCOdSogg5pOoEJ/Abwx1kzhDaTBkGRIywipacB
// SIG // K1C0KK7bRrBZG4azm4foSU45C20U30wDMB4fX3Su9VtZ
// SIG // A1PsmBbg0GI1dRtIuH0T5XpIuHdSpAeYJTsGm3pOam9E
// SIG // hk8UTyd5Jz1Qc0FMnEE+3SkMc7HH+x92DBdlBOvSUBCS
// SIG // QUns5AZ9NhVEb4m/aX35TUDBOpi2oH4x0rWuyvtT1T9Q
// SIG // hs1ekzttXXyaPz/3qSVYhN0RSQCix8ieN913jm1xi+Bb
// SIG // gTRdVLrM9ZNHiG3n71viKOSAG0DkDyrRfyMVZVqsmZRD
// SIG // P0ZVJtbE+oiV4pGaoy0Lhd6sjOD5Z3CfcXkCMfdhoinE
// SIG // MIIFaTCCBFGgAwIBAgIQVhBK7CYYy3z0EgswgntC1zAN
// SIG // BgkqhkiG9w0BAQsFADB9MQswCQYDVQQGEwJHQjEbMBkG
// SIG // A1UECBMSR3JlYXRlciBNYW5jaGVzdGVyMRAwDgYDVQQH
// SIG // EwdTYWxmb3JkMRowGAYDVQQKExFDT01PRE8gQ0EgTGlt
// SIG // aXRlZDEjMCEGA1UEAxMaQ09NT0RPIFJTQSBDb2RlIFNp
// SIG // Z25pbmcgQ0EwHhcNMTYxMjAxMDAwMDAwWhcNMTcxMjAx
// SIG // MjM1OTU5WjCB0jELMAkGA1UEBhMCVVMxDjAMBgNVBBEM
// SIG // BTk0MzA0MQswCQYDVQQIDAJDQTESMBAGA1UEBwwJUGFs
// SIG // byBBbHRvMRwwGgYDVQQJDBMzMDAwIEhhbm92ZXIgU3Ry
// SIG // ZWV0MSswKQYDVQQKDCJIZXdsZXR0IFBhY2thcmQgRW50
// SIG // ZXJwcmlzZSBDb21wYW55MRowGAYDVQQLDBFIUCBDeWJl
// SIG // ciBTZWN1cml0eTErMCkGA1UEAwwiSGV3bGV0dCBQYWNr
// SIG // YXJkIEVudGVycHJpc2UgQ29tcGFueTCCASIwDQYJKoZI
// SIG // hvcNAQEBBQADggEPADCCAQoCggEBAKGWP72YP2BCSQEV
// SIG // q6+GV5o2Hlk2G50c79TdLOBhf40Yiz3F4qcqkZUPmvlj
// SIG // w6qvthcGclgq+DW1z6P/8PjFEu/yPr2PBerPp0ttgBQl
// SIG // FidiS0KKkSTQMHoZWgtGxwUBPBTDEv/gfA4uIleUwBEP
// SIG // Q9Oa4in1dbX6dIQw9LJbLfKgHCM4biYs8WwglDBc2V1g
// SIG // 0zU1TjHia5ar7On/uIYR7iqTOabbIDQ7zthCLiwJYhIC
// SIG // p79HvIE6DAlIkYxPmiuAEnxBtKVjD784OUS0C1eEU0VB
// SIG // x+LNd+oj5rpoEuYtEUaAKtUlgSawT7jlz6UzOhzeNrny
// SIG // y91cCai2mjiAknoEA5cCAwEAAaOCAY0wggGJMB8GA1Ud
// SIG // IwQYMBaAFCmRYP+KTfrr+aZquM/55ku9Sc4SMB0GA1Ud
// SIG // DgQWBBRS2LbrO37PZl88T8F+NbSUwJHd2DAOBgNVHQ8B
// SIG // Af8EBAMCB4AwDAYDVR0TAQH/BAIwADATBgNVHSUEDDAK
// SIG // BggrBgEFBQcDAzARBglghkgBhvhCAQEEBAMCBBAwRgYD
// SIG // VR0gBD8wPTA7BgwrBgEEAbIxAQIBAwIwKzApBggrBgEF
// SIG // BQcCARYdaHR0cHM6Ly9zZWN1cmUuY29tb2RvLm5ldC9D
// SIG // UFMwQwYDVR0fBDwwOjA4oDagNIYyaHR0cDovL2NybC5j
// SIG // b21vZG9jYS5jb20vQ09NT0RPUlNBQ29kZVNpZ25pbmdD
// SIG // QS5jcmwwdAYIKwYBBQUHAQEEaDBmMD4GCCsGAQUFBzAC
// SIG // hjJodHRwOi8vY3J0LmNvbW9kb2NhLmNvbS9DT01PRE9S
// SIG // U0FDb2RlU2lnbmluZ0NBLmNydDAkBggrBgEFBQcwAYYY
// SIG // aHR0cDovL29jc3AuY29tb2RvY2EuY29tMA0GCSqGSIb3
// SIG // DQEBCwUAA4IBAQCLs1ofNEVIWnNGzLpJkHsyIgB4aXaC
// SIG // fcNkLaJLlcD9hVcab5BN9u6pN0KifP1qmvcgptgcQv2A
// SIG // xiTkxdYKD9CLN/0VA0lnc1J1N5uPD/AsPCDs4Xx+W74i
// SIG // KizV5u9djFmzOPm+/kyZEnOpsjKcLJTfsx88lT87A5Kx
// SIG // DLcTQb3oReR1YrnC2Ops2Sk3NbEY5fwjucaGhMon74O5
// SIG // 6SL9pfOkF2s3O7zh+gB8RjLUYjBkxgMBbSk067qCpcoT
// SIG // A2oEua3WDs+my/HWTT5yHcHxWe8L9FWQxp2+V+5JO+7l
// SIG // pQ+EahOxo7kkySqm29RE8fMlH3A9S7QcF/IwwCbxpMhD
// SIG // 7SQWMIIFdDCCBFygAwIBAgIQJ2buVutJ846r13Ci/ITe
// SIG // IjANBgkqhkiG9w0BAQwFADBvMQswCQYDVQQGEwJTRTEU
// SIG // MBIGA1UEChMLQWRkVHJ1c3QgQUIxJjAkBgNVBAsTHUFk
// SIG // ZFRydXN0IEV4dGVybmFsIFRUUCBOZXR3b3JrMSIwIAYD
// SIG // VQQDExlBZGRUcnVzdCBFeHRlcm5hbCBDQSBSb290MB4X
// SIG // DTAwMDUzMDEwNDgzOFoXDTIwMDUzMDEwNDgzOFowgYUx
// SIG // CzAJBgNVBAYTAkdCMRswGQYDVQQIExJHcmVhdGVyIE1h
// SIG // bmNoZXN0ZXIxEDAOBgNVBAcTB1NhbGZvcmQxGjAYBgNV
// SIG // BAoTEUNPTU9ETyBDQSBMaW1pdGVkMSswKQYDVQQDEyJD
// SIG // T01PRE8gUlNBIENlcnRpZmljYXRpb24gQXV0aG9yaXR5
// SIG // MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEA
// SIG // kehUktIKVrGsDSTdxc9EZ3SZKzejfSNwAHG8U9/E+ioS
// SIG // j0t/EFa9n3Byt2F/yUsPF6c947AEYe7/EZfH9IY+Cvo+
// SIG // XPmT5jR62RRr55yzhaCCenavcZDX7P0N+pxs+t+wgvQU
// SIG // fvm+xKYvT3+Zf7X8Z0NyvQwA1onrayzT7Y+YHBSrfuXj
// SIG // bvzYqOSSJNpDa2K4Vf3qwbxstovzDo2a5JtsaZn4eEgw
// SIG // RdWt4Q08RWD8MpZRJ7xnw8outmvqRsfHIKCxH2XeSAi6
// SIG // pE6p8oNGN4Tr6MyBSENnTnIqm1y9TBsoilwie7SrmNnu
// SIG // 4FGDwwlGTm0+mfqVF9p8M1dBPI1R7Qu2XK8sYxrfV8g/
// SIG // vOldxJuvRZnio1oktLqpVj3Pb6r/SVi+8Kj/9Lit6Tf7
// SIG // urj0Czr56ENCHonYhMsT8dm74YlguIwoVqwUHZwK53Hr
// SIG // zw7dPamWoUi9PPevtQ0iTMARgexWO/bTouJbt7IEIlKV
// SIG // gJNp6I5MZfGRAy1wdALqi2cVKWlSArvX31BqVUa/oKMo
// SIG // YX9w0MOiqiwhqkfOKJwGRXa/ghgntNWutMtQ5mv0TIZx
// SIG // MOmm3xaG4Nj/QN370EKIf6MzOi5cHkERgWPOGHFrK+ym
// SIG // ircxXDpqR+DDeVnWIBqv8mqYqnK8V0rSS527EPywTEHl
// SIG // 7R09XiidnMy/s1Hap0flhFMCAwEAAaOB9DCB8TAfBgNV
// SIG // HSMEGDAWgBStvZh6NLQm9/rEJlTvA73gJMtUGjAdBgNV
// SIG // HQ4EFgQUu69+Aj36pvE8hI6t7jiY7NkyMtQwDgYDVR0P
// SIG // AQH/BAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wEQYDVR0g
// SIG // BAowCDAGBgRVHSAAMEQGA1UdHwQ9MDswOaA3oDWGM2h0
// SIG // dHA6Ly9jcmwudXNlcnRydXN0LmNvbS9BZGRUcnVzdEV4
// SIG // dGVybmFsQ0FSb290LmNybDA1BggrBgEFBQcBAQQpMCcw
// SIG // JQYIKwYBBQUHMAGGGWh0dHA6Ly9vY3NwLnVzZXJ0cnVz
// SIG // dC5jb20wDQYJKoZIhvcNAQEMBQADggEBAGS/g/FfmoXQ
// SIG // zbihKVcN6Fr30ek+8nYEbvFScLsePP9NDXRqzIGCJdPD
// SIG // oCpdTPW6i6FtxFQJdcfjJw5dhHk3QBN39bSsHNA7qxcS
// SIG // 1u80GH4r6XnTq1dFDK8o+tDb5VCViLvfhVdpfZLYUspz
// SIG // gb8c8+a4bmYRBbMelC1/kZWSWfFMzqORcUx8Rww7Cxn2
// SIG // obFshj5cqsQugsv5B5a6SE2Q8pTIqXOi6wZ7I53eovNN
// SIG // VZ96YUWYGGjHXkBrI/V5eu+MtWuLt29G9HvxPUsE2JOA
// SIG // WVrgQSQdso8VYFhH2+9uRv0V9dlfmrPb2LjkQLPNlzmu
// SIG // hbsdjrzch5vRpu/xO28QOG8wggXgMIIDyKADAgECAhAu
// SIG // fIfMDpNKUv6U/Ry3zTSvMA0GCSqGSIb3DQEBDAUAMIGF
// SIG // MQswCQYDVQQGEwJHQjEbMBkGA1UECBMSR3JlYXRlciBN
// SIG // YW5jaGVzdGVyMRAwDgYDVQQHEwdTYWxmb3JkMRowGAYD
// SIG // VQQKExFDT01PRE8gQ0EgTGltaXRlZDErMCkGA1UEAxMi
// SIG // Q09NT0RPIFJTQSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0
// SIG // eTAeFw0xMzA1MDkwMDAwMDBaFw0yODA1MDgyMzU5NTla
// SIG // MH0xCzAJBgNVBAYTAkdCMRswGQYDVQQIExJHcmVhdGVy
// SIG // IE1hbmNoZXN0ZXIxEDAOBgNVBAcTB1NhbGZvcmQxGjAY
// SIG // BgNVBAoTEUNPTU9ETyBDQSBMaW1pdGVkMSMwIQYDVQQD
// SIG // ExpDT01PRE8gUlNBIENvZGUgU2lnbmluZyBDQTCCASIw
// SIG // DQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKaYkGN3
// SIG // kTR/itHd6WcxEevMHv0xHbO5Ylc/k7xb458eJDIRJ2u8
// SIG // UZGnz56eJbNfgagYDx0eIDAO+2F7hgmz4/2iaJ0cLJ2/
// SIG // cuPkdaDlNSOOyYruGgxkx9hCoXu1UgNLOrCOI0tLY+Ai
// SIG // lDd71XmQChQYUSzm/sES8Bw/YWEKjKLc9sMwqs0oGHVI
// SIG // wXlaCM27jFWM99R2kDozRlBzmFz0hUprD4DdXta9/akv
// SIG // wCX1+XjXjV8QwkRVPJA8MUbLcK4HqQrjr8EBb5AaI+Jf
// SIG // ONvGCF1Hs4NB8C4ANxS5Eqp5klLNhw972GIppH4wvRu1
// SIG // jHK0SPLj6CH5XkxieYsCBp9/1QsCAwEAAaOCAVEwggFN
// SIG // MB8GA1UdIwQYMBaAFLuvfgI9+qbxPISOre44mOzZMjLU
// SIG // MB0GA1UdDgQWBBQpkWD/ik366/mmarjP+eZLvUnOEjAO
// SIG // BgNVHQ8BAf8EBAMCAYYwEgYDVR0TAQH/BAgwBgEB/wIB
// SIG // ADATBgNVHSUEDDAKBggrBgEFBQcDAzARBgNVHSAECjAI
// SIG // MAYGBFUdIAAwTAYDVR0fBEUwQzBBoD+gPYY7aHR0cDov
// SIG // L2NybC5jb21vZG9jYS5jb20vQ09NT0RPUlNBQ2VydGlm
// SIG // aWNhdGlvbkF1dGhvcml0eS5jcmwwcQYIKwYBBQUHAQEE
// SIG // ZTBjMDsGCCsGAQUFBzAChi9odHRwOi8vY3J0LmNvbW9k
// SIG // b2NhLmNvbS9DT01PRE9SU0FBZGRUcnVzdENBLmNydDAk
// SIG // BggrBgEFBQcwAYYYaHR0cDovL29jc3AuY29tb2RvY2Eu
// SIG // Y29tMA0GCSqGSIb3DQEBDAUAA4ICAQACPwI5w+74yjuJ
// SIG // 3gxtTbHxTpJPr8I4LATMxWMRqwljr6ui1wI/zG8Zwz3W
// SIG // GgiU/yXYqYinKxAa4JuxByIaURw61OHpCb/mJHSvHnsW
// SIG // MW4j71RRLVIC4nUIBUzxt1HhUQDGh/Zs7hBEdldq8d9Y
// SIG // ayGqSdR8N069/7Z1VEAYNldnEc1PAuT+89r8dRfb7Lf3
// SIG // ZQkjSR9DV4PqfiB3YchN8rtlTaj3hUUHr3ppJ2WQKUCL
// SIG // 33s6UTmMqB9wea1tQiCizwxsA4xMzXMHlOdajjoEuqKh
// SIG // fB/LYzoVp9QVG6dSRzKp9L9kR9GqH1NOMjBzwm+3eIKd
// SIG // XP9Gu2siHYgL+BuqNKb8jPXdf2WMjDFXMdA27Eehz8uL
// SIG // qO8cGFjFBnfKS5tRr0wISnqP4qNS4o6OzCbkstjlOMKo
// SIG // 7caBnDVrqVhhSgqXtEtCtlWdvpnncG1Z+G0qDH8ZYF8M
// SIG // mohsMKxSCZAWG/8rndvQIMqJ6ih+Mo4Z33tIMx7XZfiu
// SIG // yfiDFJN2fWTQjs6+NX3/cjFNn569HmwvqI8MBlD7jCez
// SIG // dsn05tfDNOKMhyGGYf6/VXThIXcDCmhsu+TJqebPWSXr
// SIG // fOxFDnlmaOgizbjvmIVNlhE8CYrQf7woKBP7aspUjZJc
// SIG // zcJlmAaezkhb1LU3k0ZBfAfdz/pD77pnYf99SeC7MH1c
// SIG // gOPmFjlLpzGCBEowggRGAgEBMIGRMH0xCzAJBgNVBAYT
// SIG // AkdCMRswGQYDVQQIExJHcmVhdGVyIE1hbmNoZXN0ZXIx
// SIG // EDAOBgNVBAcTB1NhbGZvcmQxGjAYBgNVBAoTEUNPTU9E
// SIG // TyBDQSBMaW1pdGVkMSMwIQYDVQQDExpDT01PRE8gUlNB
// SIG // IENvZGUgU2lnbmluZyBDQQIQVhBK7CYYy3z0EgswgntC
// SIG // 1zANBglghkgBZQMEAgEFAKB8MBAGCisGAQQBgjcCAQwx
// SIG // AjAAMBkGCSqGSIb3DQEJAzEMBgorBgEEAYI3AgEEMBwG
// SIG // CisGAQQBgjcCAQsxDjAMBgorBgEEAYI3AgEVMC8GCSqG
// SIG // SIb3DQEJBDEiBCDc5MCD6pElwWc0qsmgLkT8ZCLJhNDu
// SIG // izJa1nCyYdPOGzANBgkqhkiG9w0BAQEFAASCAQAo3Pyw
// SIG // +d2/c4KDyk5qWY9q/sIpToOn42ljjOOhN43kf8zRAZ7b
// SIG // aSGY3DXIDwhOdUIFZ+BruSVKK7vPcwIKRWgMmdoZOHxG
// SIG // hSWJmtQguIKqiv/jYpvWH66b6DCBZibPn+9aoygFTg87
// SIG // CCoOAlb247ehlwzaI+Ip4KEbv2PZA2GUTO/j59fsDUL9
// SIG // NjwwEYqOsuGKhDRRP4S0grtsmvKlSK/W/omk+T7GnYb1
// SIG // QStyosnr7dpt1bvGaLtiR6YhKi310O95aNmTB3JhoNtz
// SIG // p4DvyKNjop831WR2JOOw0akK5MFyNmRbJ5SGadqqwUol
// SIG // DR8tWOq6h/sfahJAs5TLtNE8Pvo8oYICCzCCAgcGCSqG
// SIG // SIb3DQEJBjGCAfgwggH0AgEBMHIwXjELMAkGA1UEBhMC
// SIG // VVMxHTAbBgNVBAoTFFN5bWFudGVjIENvcnBvcmF0aW9u
// SIG // MTAwLgYDVQQDEydTeW1hbnRlYyBUaW1lIFN0YW1waW5n
// SIG // IFNlcnZpY2VzIENBIC0gRzICEA7P9DjI/r81bgTYapgb
// SIG // GlAwCQYFKw4DAhoFAKBdMBgGCSqGSIb3DQEJAzELBgkq
// SIG // hkiG9w0BBwEwHAYJKoZIhvcNAQkFMQ8XDTE3MDEyMTEw
// SIG // MjQ0OVowIwYJKoZIhvcNAQkEMRYEFK8CZCxLorRwBjsH
// SIG // qieb0RKmKuHRMA0GCSqGSIb3DQEBAQUABIIBAEWqPoFa
// SIG // gVEUachgarEc+tpu3BK862xsS4qOqYqiyH810o/hJ01+
// SIG // rGtQLNxFtLcEB5ePe18tEsItxv9Mz+wr2iPwl1iSbuSE
// SIG // 5por0SkE0U71E+uIF/hNIzPchfcJOjaqc+c6a6L0lVRA
// SIG // Qho3Ql7nHDaWCjCvx2NHlhKxuSHET+nKji+VazTB9puH
// SIG // HrYwcAVchEOxUgO25Zkh58OCc/UVfdnTk86YYifljyCZ
// SIG // ZdQzxYtAMJMYPpMWi+GCxB//p/VghZZ1aQmGQWZmZYjZ
// SIG // jcaxlMFVEWbXOo6DcyfG5yjkzOdAGWhFSNouSm9HjrU3
// SIG // KJ/NifLCHnnCFn+mq29pbjdhFF4=
// SIG // End signature block
