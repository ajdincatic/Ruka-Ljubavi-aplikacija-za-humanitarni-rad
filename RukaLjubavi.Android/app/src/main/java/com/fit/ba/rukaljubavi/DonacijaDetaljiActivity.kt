package com.fit.ba.rukaljubavi

import android.content.Intent
import android.opengl.Visibility
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Toast
import androidx.core.view.isVisible
import com.fit.ba.rukaljubavi.Models.Donacija
import com.fit.ba.rukaljubavi.Models.StatusDonacije
import com.fit.ba.rukaljubavi.Services.APIService
import com.fit.ba.rukaljubavi.Services.DonacijaService
import kotlinx.android.synthetic.main.activity_donacija_detalji.*
import kotlinx.android.synthetic.main.activity_donacija_detalji.txtBenefiktor
import kotlinx.android.synthetic.main.activity_donacija_detalji.txtDonator
import kotlinx.android.synthetic.main.activity_donacija_detalji.txtKategorija
import kotlinx.android.synthetic.main.activity_donacija_detalji.txtOpis
import kotlinx.android.synthetic.main.activity_donator_profil.*
import kotlinx.android.synthetic.main.activity_nova_donacija.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class DonacijaDetaljiActivity : AppCompatActivity() {

    val service = APIService.buildService(DonacijaService::class.java)
    var donacije: Donacija? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_donacija_detalji)
        title = "Detalji donacije"
        donacije = intent.getSerializableExtra("DONACIJA") as Donacija

        btnDetaljiDonirajOdbij.visibility = View.GONE;
        btnDetaljiDoniraj.visibility = View.GONE;

        var previousActivity = intent.getStringExtra("ACTIVITY")
        if(previousActivity.equals("AktivneDonacijeActivity") || previousActivity.equals("ZahtjeviBenefiktoraListaActivity")){
            btnDetaljiDoniraj.text = "Preuzmi"
            btnDetaljiDoniraj.visibility = View.VISIBLE;
            btnDetaljiDonirajOdbij.visibility = View.GONE;
        }

        if(!previousActivity.equals("VaseDonacijeActivity")){
            btnDetaljiDoniraj.setOnClickListener {
                preuzmiDonaciju()
            }
        }

        if(previousActivity.equals("ZahtjeviDonatoraActivity")){
            btnDetaljiDoniraj.text = "Prihvati"
            btnDetaljiDoniraj.visibility = View.VISIBLE;
            btnDetaljiDonirajOdbij.visibility = View.VISIBLE;

            btnDetaljiDonirajOdbij.setOnClickListener {
                odbijDonaciju()
            }
        }

        if(donacije!!.donatorId != 0){
            txtDonator.setText("""${donacije!!.donatorIme} ${donacije!!.donatorPrezime}""")
        }
        else{
            txtDonator.setText("")
        }
        if(donacije!!.benefiktorId != 0){
            txtBenefiktor.setText(donacije!!.benefiktorNazivKompanije)
        }
        else{
            txtBenefiktor.setText("")
        }

        txtKategorija.setText(donacije!!.nazivKategorije)
        txtStatus.setText(donacije!!.status)
        txtOpis.setText(donacije!!.opis)
        var dan = donacije!!.datumVrijeme.substring(8,10)
        var mjesec = donacije!!.datumVrijeme.substring(5,7)
        var godina = donacije!!.datumVrijeme.substring(0,4)
        txtDatum.text = "$dan.$mjesec.$godina"
    }

    private fun odbijDonaciju() {
        val requestCall = service.changeStatus(APIService.loggedUserToken, donacijaId = donacije!!.id, statusDonacije = StatusDonacije.Odbijena)

        var loading = LoadingDialog(this@DonacijaDetaljiActivity)
        loading.startLoadingDialog()

        requestCall.enqueue(object : Callback<Unit> {
            override fun onFailure(call: Call<Unit>, t: Throwable) {
                loading.stopDialog()
                Toast.makeText(
                    this@DonacijaDetaljiActivity,
                    "Error: ${t.toString()}",
                    Toast.LENGTH_SHORT
                ).show()
            }

            override fun onResponse(call: Call<Unit>, response: Response<Unit>) {
                if (response.isSuccessful) {
                    Toast.makeText(
                        this@DonacijaDetaljiActivity,
                        "Donacija odbijena.",
                        Toast.LENGTH_SHORT
                    ).show()
                    finish()
                } else {
                    Toast.makeText(
                        this@DonacijaDetaljiActivity,
                        response.message(),
                        Toast.LENGTH_SHORT
                    ).show()
                }
                loading.stopDialog()
            }
        })
    }

    private fun preuzmiDonaciju() {
        val requestCall = service.acceptStatus(APIService.loggedUserToken, donacije!!.id, APIService!!.loggedUserId)

        var loading = LoadingDialog(this@DonacijaDetaljiActivity)
        loading.startLoadingDialog()

        requestCall.enqueue(object : Callback<Unit> {
            override fun onFailure(call: Call<Unit>, t: Throwable) {
                loading.stopDialog()
                Toast.makeText(
                    this@DonacijaDetaljiActivity,
                    "Error: ${t.toString()}",
                    Toast.LENGTH_SHORT
                ).show()
            }

            override fun onResponse(call: Call<Unit>, response: Response<Unit>) {
                if (response.isSuccessful) {
                    Toast.makeText(
                        this@DonacijaDetaljiActivity,
                        "Donacija prihvaćena.",
                        Toast.LENGTH_SHORT
                    ).show()
                    finish()
                } else {
                    Toast.makeText(
                        this@DonacijaDetaljiActivity,
                        "Oznacili ste da vam kategorija donacije nije potrebna.",
                        Toast.LENGTH_SHORT
                    ).show()
                }
                loading.stopDialog()
            }
        })
    }
}