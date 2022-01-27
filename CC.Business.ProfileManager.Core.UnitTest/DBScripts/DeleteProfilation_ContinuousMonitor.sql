DECLARE
  lUidProfile        cribiscom.ccpe_profilations.uidprofile%TYPE;
BEGIN

  lUidProfile := hextoraw('417DBFA93291D3B9E05007D4A24C7A32');
  
  

  delete from cribiscom.ccpe_profilations where uidprofile = lUidProfile;

     
  COMMIT;
  
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK;
    RAISE;
END;
/
EXIT;
