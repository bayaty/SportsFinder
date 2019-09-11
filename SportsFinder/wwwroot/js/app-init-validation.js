var v = new aspnetValidation.ValidationService();
v.addMvcProviders();
v.scanMessages();
v.scanInputs();